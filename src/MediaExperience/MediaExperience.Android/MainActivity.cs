using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.MediaManager;
using Plugin.MediaManager.Forms.Android;

namespace MediaExperience.Droid
{
    [Activity(Label = "MediaExperience", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Bootstrap.DroidBootstrap.Init();
            Plugin.Rome.Android.RomeService.Init();
            CrossMediaManager.Current.VideoPlayer = new VideoPlayerImplementation();
            VideoViewRenderer.Init();
            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}
