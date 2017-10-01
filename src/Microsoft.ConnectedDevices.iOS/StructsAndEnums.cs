using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;

namespace Microsoft.ConnectedDevices
{
    [Native]
    public enum MCDRemoteSystemStatus : long
    {
        Unknown = 0,
        DiscoveringAvailability,
        Available,
        Unavailable
    }

    [Native]
    public enum MCDRemoteSystemKind : long
    {
        Unknown = 0,
        Desktop,
        Holographic,
        Phone,
        Xbox,
        Hub
    }

    static class CFunctions
    {
        // extern NSString * MCDRemoteSystemFriendlyNameForKind (MCDRemoteSystemKind type) __attribute__((visibility("default")));
        [DllImport ("__Internal")]
    //  [Verify (PlatformInvoke)]
        static extern NSString MCDRemoteSystemFriendlyNameForKind (MCDRemoteSystemKind type);
    }

    [Native]
    public enum MCDAppServiceResponseStatus : long
    {
        Success = 0,
        Failure = 1,
        ResourceLimitsExceeded = 2,
        Unknown = 3,
        RemoteSystemUnavailable = 4,
        MessageTooLarge = 5
    }

    [Native]
    public enum MCDAppServiceClientClosedStatus : long
    {
        Completed = 0,
        Cancelled = 1,
        ResourceLimitsExceeded = 2,
        Unknown = 3
    }

    [Native]
    public enum MCDAppServiceClientConnectionStatus : long
    {
        Success = 0,
        AppNotInstalled = 1,
        AppUnavailable = 2,
        AppServiceUnavailable = 3,
        Unknown = 4,
        RemoteSystemUnavailable = 5,
        RemoteSystemNotSupportedByApp = 6,
        NotAuthorized = 7
    }

    [Native]
    public enum MCDRemoteLauncherUriStatus : long
    {
        Unknown = 0,
        Success,
        AppUnavailable,
        ProtocolUnavailable,
        RemoteSystemUnavailable,
        BundleTooLarge,
        DeniedByLocalSystem,
        DeniedByRemoteSystem
    }

    [Native]
    public enum MCDRemoteSystemDiscoveryType : long
    {
        Cloud = 1,
        Proximal = 1 << 1,
        Any = 65535
    }

    [Native]
    public enum MCDRemoteSystemStatusType : long
    {
        Available = 0,
        Any
    }
}