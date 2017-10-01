using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Plugin.Rome
{
    public interface IRomeService
    {
        bool IsInitialized { get; }
        IReadOnlyList<RomeRemoteSystem> RemoteSystems { get; }
        Task InitializeAsync(IRomeServiceUpdater updater, string appId);
        Task<bool> RemoteLaunchUri(RomeRemoteSystem remoteSystem, Uri uri);
        Task<bool> SendCommandAsync(RomeRemoteSystem remoteSystem, string command);
    }
}