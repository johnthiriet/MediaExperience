using Windows.UI.Xaml;
using Plugin.MediaManager;

namespace MediaExperience.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            var application = ((MediaExperience.UWP.App) Application.Current).XApp;
            LoadApplication(application);
        }

        //public VideoSurface Surface => VideoCanvas;
    }
}
