using MediaExperience.Bootstrap;

namespace MediaExperience.iOS.Bootstrap
{
    public class TouchBootstrap : BootstrapBase
    {
        public static void Init()
        {
            Current = new TouchBootstrap();
        }

        protected override void InitializeNativeServices()
        {
            Container.Register(() => Plugin.Rome.RomeService.Current);
        }
    }
}
