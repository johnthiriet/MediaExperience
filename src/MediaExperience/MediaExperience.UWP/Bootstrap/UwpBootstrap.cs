using MediaExperience.Bootstrap;
using Plugin.Rome;

namespace MediaExperience.UWP.Bootstrap
{
    public class UWPBootstrap : BootstrapBase
    {
        public static void Init()
        {
            Current = new UWPBootstrap();
        }

        protected override void InitializeNativeServices()
        {
            Container.Register(() => RomeService.Current);
        }
    }
}
