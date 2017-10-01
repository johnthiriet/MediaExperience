using GalaSoft.MvvmLight.Ioc;
using MediaExperience.Services;
using MediaExperience.ViewModels;

namespace MediaExperience.Bootstrap
{
    public abstract class BootstrapBase
    {
        public static BootstrapBase Current { get; protected set; }

        protected ISimpleIoc Container { get; private set; }

        protected BootstrapBase()
        {
        }

        protected abstract void InitializeNativeServices();

        private void InitializeSharedServices()
        {
            Container.Register<IVideoService, VideoService>();

            Container.Register<MainViewModel>();
			Container.Register<VideoViewModel>();
		}

        public void Run()
        {
            Container = SimpleIoc.Default;

            InitializeNativeServices();
            InitializeSharedServices();
		}
    }
}
