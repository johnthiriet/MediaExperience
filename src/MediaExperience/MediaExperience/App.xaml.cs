using System;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using MediaExperience.ViewModels;
using MediaExperience.Views;
using Xamarin.Forms;

namespace MediaExperience
{
    public delegate void DeepLinkRequestDelegate(Uri parameter);

    public partial class App : Application
    {
        public event DeepLinkRequestDelegate OnDeepLinkRequest;

        public App()
        {
            InitializeComponent();
     
            Bootstrap.BootstrapBase.Current.Run();
            MainPage = new NavigationPage(new MainPage());
            OnDeepLinkRequest += App_OnDeepLinkRequest;
        }

        //To handle navigation
        private void App_OnDeepLinkRequest(Uri parameter)
        {
            

            if (parameter.AbsoluteUri.StartsWith(Protocol.Scheme, StringComparison.OrdinalIgnoreCase))
            {
                 HandleDeepLinkingAsync(parameter).FireAndForgetSafeAsync();
            }
        }

        private async Task HandleDeepLinkingAsync(Uri parameter)
        {
            var page = MainPage as NavigationPage;
            var len = Protocol.Scheme.Length;
            var uri = parameter.AbsoluteUri.Substring(len, parameter.AbsoluteUri.Length - len);
            var urlParameters = uri.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);

            if (page != null)
            {
                string protocol = urlParameters[0];
                object[] protocolParameters;

                if (protocol == Protocol.Video)
                {
                    int id = int.Parse(urlParameters[1]);
                    var ts = TimeSpan.Parse(urlParameters[2]);

                    if (page.CurrentPage?.GetType() != typeof(VideoPage))
                    {
                        await page.PushAsync(new VideoPage(id, ts));
                        return;
                    }

                    protocolParameters = new object[] {id, ts};
                }
                else
                {
                    protocolParameters = new object[0];
                }

                var vm = SimpleIoc.Default.GetInstance<VideoViewModel>();
                await vm.ExecuteProtocolAsync(protocol, protocolParameters);
            }
        }
        
        public void DeepLinkRequest(Uri uri)
        {
            OnDeepLinkRequest?.Invoke(uri);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
