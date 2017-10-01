using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MediaExperience.Models;
using MediaExperience.Services;
using Plugin.Rome;

namespace MediaExperience.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IVideoService _videoService;
        private readonly IRomeService _romeService;

        public MainViewModel(IVideoService videoService, IRomeService romeService)
        {
            _videoService = videoService;
            _romeService = romeService;

        }

        private Video[] _videos;

        public Video[] Videos
        {
            get => _videos;
            set => Set(ref _videos, value);
        }

        private async Task StartAsync()
        {
            Videos = await _videoService.GetVideosAsync();
            await _romeService.InitializeAsync(null, Secrets.AppId);
        }

        public void Start()
        {
            StartAsync().FireAndForgetSafeAsync();
        }
    }
}
