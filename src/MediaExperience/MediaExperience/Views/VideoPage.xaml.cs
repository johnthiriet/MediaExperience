using System;
using System.Threading.Tasks;
using MediaExperience.Models;
using MediaExperience.ViewModels;
using Plugin.MediaManager;
using Xamarin.Forms;

namespace MediaExperience.Views
{
    public partial class VideoPage : ContentPage
	{
		private readonly VideoViewModel _vm;
        private readonly int _video;
	    private readonly TimeSpan _position;

	    public VideoPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            SizeChanged += (sender, args) =>
            {
                if (Device.RuntimePlatform != Device.Android) return;
                const double ratio = 16.0d / 9.0d;
                double height = Width / ratio;
                videoView.HeightRequest = height;
                videoView.VerticalOptions = LayoutOptions.Center;
            };
            BindingContext = _vm = GalaSoft.MvvmLight.Ioc.SimpleIoc.Default.GetInstance<VideoViewModel>();
        }

	    public VideoPage(int video, TimeSpan position) : this()
	    {
	        _video = video;
	        _position = position;
	    }

        public VideoPage(Video video, TimeSpan position) : this(video.Id, position)
        {
        }

		protected override void OnAppearing()
		{
			base.OnAppearing();

            _vm.Start(CrossMediaManager.Current.PlaybackController, _video, _position);
		}

	    private void OnShowHideButtonClicked(object sender, EventArgs e)
	    {
            AnimateControlGridAsync().FireAndForgetSafeAsync();
	    }

	    private async Task AnimateControlGridAsync()
	    {
	        if (videoControlsGrid.Opacity > 0)
	        {
	            await videoControlsGrid.FadeTo(0);
	            videoControlsGrid.IsVisible = false;
	        }
	        else
	        {
	            await videoControlsGrid.FadeTo(1);
	            videoControlsGrid.IsVisible = true;
	        }
	    }

	    protected override void OnDisappearing()
	    {
	        base.OnDisappearing();

	        _vm.Stop.ExecuteAsync().FireAndForgetSafeAsync();
	    }
    }
}
