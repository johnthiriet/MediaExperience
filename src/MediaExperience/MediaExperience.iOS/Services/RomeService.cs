using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.Rome;

namespace MediaExperience.iOS.Services
{
    public class RomeService : Plugin.Rome.RomeService
    {
        public override IReadOnlyList<RomeRemoteSystem> RemoteSystems => base._remoteSystems;

        public override Task InitializeAsync(IRomeServiceUpdater updater, string appId)
        {
            return Task.FromResult(false);
        }

        public override Task<bool> RemoteLaunchUri(RomeRemoteSystem remoteSystem, Uri uri)
        {
            return Task.FromResult(false);
        }

        public override Task<bool> SendCommandAsync(RomeRemoteSystem remoteSystem, string command)
        {
            return Task.FromResult(false);
        }
    }
}
