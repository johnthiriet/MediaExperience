//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

typedef NS_ENUM(NSInteger, MCDAppServiceResponseStatus) {
    MCDAppServiceResponseStatusSuccess = 0,
    MCDAppServiceResponseStatusFailure = 1,
    MCDAppServiceResponseStatusResourceLimitsExceeded = 2,
    MCDAppServiceResponseStatusUnknown = 3,
    MCDAppServiceResponseStatusRemoteSystemUnavailable = 4,
    MCDAppServiceResponseStatusMessageTooLarge = 5,
};
