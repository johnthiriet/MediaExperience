//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

typedef NS_ENUM(NSInteger, MCDAppServiceClientClosedStatus) {
    MCDAppServiceClientClosedStatusCompleted = 0,
    MCDAppServiceClientClosedStatusCancelled = 1,
    MCDAppServiceClientClosedStatusResourceLimitsExceeded = 2,
    MCDAppServiceClientClosedStatusUnknown = 3
};
