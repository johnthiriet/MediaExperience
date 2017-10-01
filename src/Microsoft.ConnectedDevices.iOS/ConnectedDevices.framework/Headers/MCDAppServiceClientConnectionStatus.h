//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

typedef NS_ENUM(NSInteger, MCDAppServiceClientConnectionStatus) {
    MCDAppServiceClientConnectionStatusSuccess = 0,
    MCDAppServiceClientConnectionStatusAppNotInstalled = 1,
    MCDAppServiceClientConnectionStatusAppUnavailable = 2,
    MCDAppServiceClientConnectionStatusAppServiceUnavailable = 3,
    MCDAppServiceClientConnectionStatusUnknown = 4,
    MCDAppServiceClientConnectionStatusRemoteSystemUnavailable = 5,
    MCDAppServiceClientConnectionStatusRemoteSystemNotSupportedByApp = 6,
    MCDAppServiceClientConnectionStatusNotAuthorized = 7
};
