using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MediaExperience.Commands;
using MediaExperience.Models;
using MediaExperience.Services;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.EventArguments;
using Plugin.Rome;
using Xamarin.Forms;

namespace MediaExperience.ViewModels
{
    public class VideoViewModel : ViewModelBase
    {
        private readonly IVideoService _videoService;
        private readonly IRomeService _romeService;
        private Video _video;
        private bool _isConnected;
        private RomeRemoteSystem _selectedDevice;
        private bool _isBusy;
        private TimeSpan _initialPosition;
        private TaskCompletionSource<bool> _tcs;

        public bool IsBusy
        {
            get => _isBusy;
            set => Set(ref _isBusy, value);
        }

        public RomeRemoteSystem SelectedDevice
        {
            get => _selectedDevice;
            set => Set(ref _selectedDevice, value);
        }

        private string _duration;
        public string Duration
        {
            get => _duration;
            set => Set(ref _duration, value);
        }

        private double _progress;
        public double Progress
        {
            get => _progress;
            set => Set(ref _progress, value);
        }

        public AsyncCommand Connect { get; }

        public AsyncCommand Pause { get; }

        public AsyncCommand Play { get; }

        public AsyncCommand Minus30 { get; }

        public AsyncCommand Plus30 { get; }

        public AsyncCommand Stop { get; }

        private IPlaybackController PlaybackController { get; set; }

        public VideoViewModel(IVideoService videoService, IRomeService romeService)
        {
            _videoService = videoService;
            _romeService = romeService;
            Connect = new AsyncCommand(ExecuteConnectAsync);
            Pause = new AsyncCommand(ExecutePauseAsync);
            Play = new AsyncCommand(ExecutePlayAsync);
            Minus30 = new AsyncCommand(ExecuteMinus30Async);
            Plus30 = new AsyncCommand(ExecutePlus30Async);
            Stop = new AsyncCommand(ExecuteStopAsync);

            CrossMediaManager.Current.StatusChanged += OnCurrentOnStatusChanged;
            CrossMediaManager.Current.PlayingChanged += OnCurrentOnPlayingChanged;
        }

        private void OnCurrentOnPlayingChanged(object sender, PlayingChangedEventArgs args)
        {
            Duration = args.Duration.ToString("g");
            Progress = args.Progress;
        }

        private ObservableCollection<RomeRemoteSystem> _devices;
        private int _videoId;

        public ObservableCollection<RomeRemoteSystem> Devices
        { 
            get => _devices; 
            set => Set(ref _devices, value); 
        }

        public Video Video
        {
            get => _video;
            set => Set(ref _video, value);
        }

        public async Task ExecuteProtocolAsync(string protocol, params object[] parameters)
        {
            switch (protocol)
            {
                case Protocol.Video:
                    var videoId = (int) parameters[0];
                    var position = (TimeSpan) parameters[1];
                    if (videoId != _videoId)
                        await StartAsync(PlaybackController, videoId, position);
                    else
                    {
                        _initialPosition = position;
                        await CrossMediaManager.Current.Seek(position);
                    }
                    break;
                case Protocol.Minus30:
                    await Minus30.ExecuteAsync();
                    break;
                case Protocol.Pause:
                    await Pause.ExecuteAsync();
                    break;
                case Protocol.Play:
                    await Play.ExecuteAsync();
                    break;
                case Protocol.Plus30:
                    await Plus30.ExecuteAsync();
                    break;
                case Protocol.Stop:
                    await Stop.ExecuteAsync();
                    break;
                default:
                    throw new NotImplementedException("Unknown protocol");
            }
        }

        private async Task ExecuteMinus30Async()
        {
            try
            {
                IsBusy = true;

                if (_isConnected)
                {
                    await SendCommandAsync(_selectedDevice, Protocol.Minus30);
                }
                else
                {
                    var position = CrossMediaManager.Current.Position;
                    var newTime = position.Subtract(TimeSpan.FromSeconds(30)).TotalSeconds;
                    await PlaybackController.SeekTo(newTime);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task ExecutePlus30Async()
        {
            try
            {
                IsBusy = true;
                if (_isConnected)
                {
                    await SendCommandAsync(_selectedDevice, Protocol.Plus30);
                }
                else
                {
                    var position = CrossMediaManager.Current.Position;
                    var newTime = position.Add(TimeSpan.FromSeconds(30)).TotalSeconds;
                    await PlaybackController.SeekTo(newTime);
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task ExecutePlayAsync()
        {
            try
            {
                IsBusy = true;
                if (_isConnected)
                    await SendCommandAsync(_selectedDevice, Protocol.Play);
                else
                    await PlaybackController.Play();
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task ExecutePauseAsync()
        {
            try
            {
                IsBusy = true;
                if (_isConnected)
                    await SendCommandAsync(_selectedDevice, Protocol.Pause);
                else
                    await PlaybackController.Pause();
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task ExecuteStopAsync()
        {
            try
            {
                IsBusy = true;
                if (_isConnected)
                    await SendCommandAsync(_selectedDevice, Protocol.Stop);
                else
                    await PlaybackController.Stop();
            }
            finally
            {
                IsBusy = false;
            }
        }

        private Task<bool> SendCommandAsync(RomeRemoteSystem device, string command, params object[] parameters)
        {
            var sb = new StringBuilder(Protocol.Scheme + command);
            foreach (var t in parameters ?? Enumerable.Empty<object>())
            {
                sb.Append("/");
                sb.Append(t);
            }

            var uri = new Uri(sb.ToString());
            return _romeService.RemoteLaunchUri(device, uri);
        }

        private async Task ExecuteConnectAsync()
        {
            if (_selectedDevice == null)
                return;

            IsBusy = true;

            await PlaybackController.Pause();

            TimeSpan position = CrossMediaManager.Current.Position;
            _isConnected = true;

            await _romeService.RemoteLaunchUri(_selectedDevice, new Uri(Protocol.Scheme + Protocol.Video + "/" + _videoId + "/" + position));

            IsBusy = false;
        }

        public void Start(IPlaybackController playbackController, int videoId, TimeSpan position)
        {
            StartAsync(playbackController, videoId, position).FireAndForgetSafeAsync();
        }

        private async Task StartAsync(IPlaybackController playbackController, int videoId, TimeSpan position)
        {
            try
            {
                IsBusy = true;
                _videoId = videoId;
                _initialPosition = position;
                PlaybackController = playbackController;

                if (CrossMediaManager.Current.Status == MediaPlayerStatus.Playing)
                    await PlaybackController.Stop();
                Video = null;

                _tcs?.TrySetCanceled();
                _tcs = new TaskCompletionSource<bool>();
                
                Video = await _videoService.GetVideoAsync(videoId);

                var updater = new RomeServiceUpdater(
                    x => Device.BeginInvokeOnMainThread(() => Devices.Add(x)),
                    x => Devices = new ObservableCollection<RomeRemoteSystem>(_romeService.RemoteSystems),
                    x => Device.BeginInvokeOnMainThread(() => Devices.Remove(x)));

                var initTask = _romeService.InitializeAsync(updater, Secrets.AppId);
                await _tcs.Task;
                _tcs = null;

                Devices = new ObservableCollection<RomeRemoteSystem>(_romeService?.RemoteSystems ?? Enumerable.Empty<RomeRemoteSystem>());
                SelectedDevice = Devices?.FirstOrDefault();

                await initTask;

                SelectedDevice = Devices?.FirstOrDefault();
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task HandleStatusChangedAsync(StatusChangedEventArgs args)
        {
            if (args.Status == MediaPlayerStatus.Playing && _tcs != null)
            {
                if (_initialPosition != TimeSpan.Zero)
                    await PlaybackController.SeekTo(_initialPosition.TotalSeconds);

                _tcs.TrySetResult(true);
            }
        }

        private void OnCurrentOnStatusChanged(object sender, StatusChangedEventArgs args)
        {
            HandleStatusChangedAsync(args).FireAndForgetSafeAsync();
        }
    }
}
