using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.System;
using Windows.System.RemoteSystems;

namespace Plugin.Rome.UWP
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

        private RemoteSystemWatcher _remoteSystemWatcher;
        private IRomeServiceUpdater _romeServiceUpdater;

        private List<IRemoteSystemFilter> makeFilterList()
        {
            // construct an empty list
            List<IRemoteSystemFilter> localListOfFilters = new List<IRemoteSystemFilter>();

            // construct a discovery type filter that only allows "proximal" connections:
            RemoteSystemDiscoveryTypeFilter discoveryFilter = new RemoteSystemDiscoveryTypeFilter(RemoteSystemDiscoveryType.Proximal);


            // construct a device type filter that only allows desktop and mobile devices:
            // For this kind of filter, we must first create an IIterable of strings representing the device types to allow.
            // These strings are stored as static read-only properties of the RemoteSystemKinds class.
            List<String> listOfTypes = new List<String>();
            listOfTypes.Add(RemoteSystemKinds.Desktop);
            listOfTypes.Add(RemoteSystemKinds.Phone);

            // Put the list of device types into the constructor of the filter
            RemoteSystemKindFilter kindFilter = new RemoteSystemKindFilter(listOfTypes);


            // construct an availibility status filter that only allows devices marked as available:
            RemoteSystemStatusTypeFilter statusFilter = new RemoteSystemStatusTypeFilter(RemoteSystemStatusType.Available);


            // add the 3 filters to the listL
            localListOfFilters.Add(discoveryFilter);
            localListOfFilters.Add(kindFilter);
            localListOfFilters.Add(statusFilter);

            // return the list
            return localListOfFilters;
        }
        
        private void RemoteSystemWatcher_RemoteSystemUpdated(RemoteSystemWatcher watcher, RemoteSystemUpdatedEventArgs args)
        {
            var system = _remoteSystems.First(x => x.Id == args.RemoteSystem.Id);
            _remoteSystems.Remove(system);
            _remoteSystems.Add(ToRomeRemoteSystem(args.RemoteSystem));

        }

        private void RemoteSystemWatcher_RemoteSystemRemoved(RemoteSystemWatcher watcher, RemoteSystemRemovedEventArgs args)
        {
            var system = _remoteSystems.First(x => x.Id == args.RemoteSystemId);
            _remoteSystems.Remove(system);
            _romeServiceUpdater?.Remove(system);
        }

        private void RemoteSystemWatcherOnRemoteSystemAdded(RemoteSystemWatcher watcher, RemoteSystemAddedEventArgs args)
        {
            var system = ToRomeRemoteSystem(args.RemoteSystem);
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

        protected override void DiscoverDevices()
        {
            if (_remoteSystems == null)
                return;

            //create watcher
            _remoteSystemWatcher = RemoteSystem.CreateWatcher(makeFilterList());
 
            //hook up event handlers
            _remoteSystemWatcher.RemoteSystemAdded += RemoteSystemWatcherOnRemoteSystemAdded;
            _remoteSystemWatcher.RemoteSystemRemoved += RemoteSystemWatcher_RemoteSystemRemoved;
            _remoteSystemWatcher.RemoteSystemUpdated += RemoteSystemWatcher_RemoteSystemUpdated;
 
            //start watcher
            _remoteSystemWatcher.Start();
        }
        
        public override IReadOnlyList<RomeRemoteSystem> RemoteSystems => _remoteSystems.ToList();

        public override async Task InitializeAsync(IRomeServiceUpdater updater, string appId)
        {
            _romeServiceUpdater = updater;

            if (IsInitialized == true)
                return;
 
            await RemoteSystem.RequestAccessAsync();

            DiscoverDevices();
            IsInitialized = true;
        }

        public override async Task<bool> RemoteLaunchUri(RomeRemoteSystem remoteSystem, Uri uri)
        {
            var system = _remoteSystems.First(x => x == remoteSystem);
            var request = new RemoteSystemConnectionRequest((RemoteSystem)system.NativeObject);
            var launchUriStatus = await RemoteLauncher.LaunchUriAsync(request, uri);
            return launchUriStatus == RemoteLaunchUriStatus.Success;
        }

        public override Task<bool> SendCommandAsync(RomeRemoteSystem remoteSystem, string command)
        {
            return Task.FromResult(true);
        }
    }
}
