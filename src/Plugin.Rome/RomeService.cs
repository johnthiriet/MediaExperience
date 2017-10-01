using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plugin.Rome
{
    public abstract class RomeService : IRomeService
    {
        // AppServiceName for the Windows host
        public const string appServiceName = "com.mediaexperience.videocontroller";

        // PackageFamilyName for the Windows host 
        public const string packageFamilyName = "4aaa9320-e7ef-4637-9f0b-7eb229e27a26_v2eq8qs7wm15j";

        public static IRomeService Current { get; protected set; }

        protected readonly List<RomeRemoteSystem> _remoteSystems = new List<RomeRemoteSystem>();

        protected RomeService()
        {
            
        }

        protected virtual void DiscoverDevices()
        {
        }

        public bool IsInitialized { get; protected set; }

        public abstract IReadOnlyList<RomeRemoteSystem> RemoteSystems { get; }

        public abstract Task InitializeAsync(IRomeServiceUpdater updater, string appId);

        public abstract Task<bool> RemoteLaunchUri(RomeRemoteSystem remoteSystem, Uri uri);

        public abstract Task<bool> SendCommandAsync(RomeRemoteSystem remoteSystem, string command);
    }
}