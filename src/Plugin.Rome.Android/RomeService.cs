using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Net.Wifi;
using Android.OS;
using Android.Webkit;
using Android.Widget;
using Microsoft.ConnectedDevices;

namespace Plugin.Rome.Android
{
    public class RomeService : Plugin.Rome.RomeService
    {
        public static void Init()
        {
            Current = new RomeService();
        }

        private RomeService()
        {
            
        }

        private WebView _webView;
        private RemoteSystemWatcher _remoteSystemWatcher;
        
        private IRomeServiceUpdater _romeServiceUpdater;
        private AppServiceConnection _appServiceClientConnection;
        
        public override IReadOnlyList<RomeRemoteSystem> RemoteSystems => _remoteSystems.ToList();

        private Context Context => CurrentActivity.CrossCurrentActivity.Current?.Activity;

        public override async Task InitializeAsync(IRomeServiceUpdater updater, string appId)
        {
            _romeServiceUpdater = updater;

            if (IsInitialized)
                return;
            
			Platform.FetchAuthCode += Platform_FetchAuthCode;

			await Platform.InitializeAsync(Context.ApplicationContext, appId);
			DiscoverDevices();
            IsInitialized = true;
        }

        private async void Platform_FetchAuthCode(string oauthUrl)
        {
            try
            {
                await AuthenticateWithOAuth(oauthUrl);
                Platform.FetchAuthCode -= Platform_FetchAuthCode;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private Task AuthenticateWithOAuth(string oauthUrl)
        {
            var authDialog = new Dialog(Context);
            var tcs = new TaskCompletionSource<object>();
            
            var linearLayout = new LinearLayout(authDialog.Context);
            _webView = new WebView(authDialog.Context);
            linearLayout.AddView(_webView);
            authDialog.SetContentView(linearLayout);

            _webView.SetWebChromeClient(new WebChromeClient());
            _webView.Settings.JavaScriptEnabled = true;
            _webView.Settings.DomStorageEnabled = true;
            _webView.LoadUrl(oauthUrl);

            var msa = new MsaWebViewClient();
            _webView.SetWebViewClient(msa);
            authDialog.Show();
            authDialog.SetCancelable(true);

            void OnMsaOnFinished(object sender, EventArgs args)
            {
                tcs.TrySetResult(null);
                msa.Finished -= OnMsaOnFinished;
            }

            msa.Finished += OnMsaOnFinished;

            return tcs.Task;
        }
      
        protected override void DiscoverDevices()
        {
            if (_remoteSystemWatcher != null)
                return;

            //create watcher
            _remoteSystemWatcher = RemoteSystem.CreateWatcher();

            //hook up event handlers
            _remoteSystemWatcher.RemoteSystemAdded += RemoteSystemWatcherOnRemoteSystemAdded;
            _remoteSystemWatcher.RemoteSystemRemoved += RemoteSystemWatcher_RemoteSystemRemoved;
            _remoteSystemWatcher.RemoteSystemUpdated += RemoteSystemWatcher_RemoteSystemUpdated;
 
            //start watcher
            _remoteSystemWatcher.Start();
        }

        private void RemoteSystemWatcher_RemoteSystemUpdated(RemoteSystemWatcher watcher, RemoteSystemUpdatedEventArgs args)
        {
            var system = _remoteSystems.First(x => x.Id == args.P0.Id);
            _remoteSystems.Remove(system);
            _remoteSystems?.Add(ToRomeRemoteSystem(args.P0));
        }

        private void RemoteSystemWatcher_RemoteSystemRemoved(RemoteSystemWatcher watcher, RemoteSystemRemovedEventArgs args)
        {
            var system = _remoteSystems.First(x => x.Id == args.P0);
            _remoteSystems.Remove(system);
            _romeServiceUpdater?.Remove(system);
        }

        private void RemoteSystemWatcherOnRemoteSystemAdded(RemoteSystemWatcher watcher, RemoteSystemAddedEventArgs args)
        {
            var system = ToRomeRemoteSystem(args.P0);
            _remoteSystems.Add(system);
            _romeServiceUpdater?.Add(system);
        }

        private static RomeRemoteSystem ToRomeRemoteSystem(RemoteSystem rs)
        {
            return new RomeRemoteSystem(rs)
            {
                DisplayName = rs.DisplayName,
                Id = rs.Id,
                Kind = rs.Kind.ToString(),
                Status = rs.Status.ToString()
            };
        }

        public override async Task<bool> RemoteLaunchUri(RomeRemoteSystem remoteSystem, Uri uri)
        {
            var system = (RemoteSystem)remoteSystem.NativeObject;
            var request = new RemoteSystemConnectionRequest(system);
            var launchUriStatus = await RemoteLauncher.LaunchUriAsync(request, uri);
            return launchUriStatus == RemoteLaunchUriStatus.Success;
        }

        public override async Task<bool> SendCommandAsync(RomeRemoteSystem remoteSystem, string command)
        {
         //   return RemoteLaunchUri(remoteSystem, new Uri(command));
            if (_appServiceClientConnection == null)
            {
                var system = (RemoteSystem)remoteSystem.NativeObject;
                var connectionRequest = new RemoteSystemConnectionRequest(system);

                // Construct an AppServiceClientConnection 
                _appServiceClientConnection =
                    new AppServiceConnection(appServiceName, packageFamilyName, connectionRequest);


                // open the connection (will throw a ConnectedDevicesException if there is an error)
                try
                {
                    AppServiceConnectionStatus status = await _appServiceClientConnection.OpenRemoteAsync();
                    if (status != AppServiceConnectionStatus.Success)
                    {
                        _appServiceClientConnection = null;
                        return false;
                    }
                }
                catch (ConnectedDevicesException e)
                {
                    _appServiceClientConnection = null;
                    return false;
                }
            }

            var message = new Bundle();
            message.PutString("Command", command);
            try
            {
                var response = await _appServiceClientConnection.SendMessageAsync(message);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;

        }

        private class MsaWebViewClient : WebViewClient
        {
            private bool _authComplete = false;

            public event EventHandler Finished;

            public override void OnPageFinished(WebView view, string url)
            {
                base.OnPageFinished(view, url);
                if (url.Contains("?code=") && !_authComplete)
                {
                    _authComplete = true;
                    Console.WriteLine("Page finished successfully");

                    var uri = global::Android.Net.Uri.Parse(url);
                    string token = uri.GetQueryParameter("code");
  
                    Finished?.Invoke(this, EventArgs.Empty);
                    
                    Platform.SetAuthCode(token);
                }
                else if (url.Contains("error=access_denied"))
                {
                    _authComplete = true;
                    Console.WriteLine("Page finished failed with ACCESS_DENIED_HERE");
                    //Intent resultIntent = new Intent();
                    //_parentActivity.SetResult(0, resultIntent);
                    Finished?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    var uri = new Uri(url);

                    var description = uri.Query
                        .Replace("?", string.Empty)
                        .Split('&')
                        .Select(x => x.Split('='))
                        .ToDictionary(x => x[0], y => System.Net.WebUtility.UrlDecode(y[1]))
                        .GetValueOrDefault("error_description");
                    Console.Error.WriteLine(description);
                    Finished?.Invoke(this, EventArgs.Empty);
                   // throw new InvalidOperationException(System.Net.WebUtility.UrlDecode(description));
                }
            }
        }
    }
}