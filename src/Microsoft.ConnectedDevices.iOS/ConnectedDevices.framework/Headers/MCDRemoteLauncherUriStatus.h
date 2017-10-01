//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

typedef NS_ENUM(NSInteger, MCDRemoteLauncherUriStatus) {
    MCDRemoteLauncherUriStatusUnknown = 0,
    MCDRemoteLauncherUriStatusSuccess,
    MCDRemoteLauncherUriStatusAppUnavailable,
    MCDRemoteLauncherUriStatusProtocolUnavailable,
    MCDRemoteLauncherUriStatusRemoteSystemUnavailable,
    MCDRemoteLauncherUriStatusBundleTooLarge,
    MCDRemoteLauncherUriStatusDeniedByLocalSystem,
    MCDRemoteLauncherUriStatusDeniedByRemoteSystem
};
