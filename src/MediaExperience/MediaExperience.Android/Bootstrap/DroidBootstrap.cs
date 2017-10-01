using System.ComponentModel;
using MediaExperience.Bootstrap;
using MediaExperience.Services;
using Plugin.Rome;

namespace MediaExperience.Droid.Bootstrap
{
    public class DroidBootstrap : BootstrapBase
    {
        public static void Init()
        {
            Current = new DroidBootstrap();
        }

        protected override void InitializeNativeServices()
        {
            Container.Register(() => RomeService.Current);
        }
    }
}
