using System;
using Windows.ApplicationModel.AppService;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MediaExperience.UWP.RemoteController
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private AppServiceConnection _appServiceConnection;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            // Add the connection.
            if (_appServiceConnection == null)
            {
                _appServiceConnection = new AppServiceConnection();

                // Here, we use the app service name defined in the app service provider's Package.appxmanifest file in the <Extension> section.
                _appServiceConnection.AppServiceName = "com.mediaexperience.videocontroller";

                // Use Windows.ApplicationModel.Package.Current.Id.FamilyName within the app service provider to get this value.
                _appServiceConnection.PackageFamilyName = "4aaa9320-e7ef-4637-9f0b-7eb229e27a26_v2eq8qs7wm15j";

                var status = await this._appServiceConnection.OpenAsync();
                if (status != AppServiceConnectionStatus.Success)
                {
                    label.Text = "Failed to connect";
                    return;
                }
            }

            // Call the service.
            var message = new ValueSet();
            var content = ((Button) sender).Content;
            if (content != null)
                message.Add("Command", content.ToString());
            AppServiceResponse response = await _appServiceConnection.SendMessageAsync(message);
        }

        private void LaunchApp_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
