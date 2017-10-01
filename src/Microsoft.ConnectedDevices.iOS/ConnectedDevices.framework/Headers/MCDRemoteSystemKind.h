//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

#import "MCDCommon.h"

typedef NS_ENUM(NSInteger, MCDRemoteSystemKind) {
    MCDRemoteSystemKindUnknown = 0,
    MCDRemoteSystemKindDesktop,
    MCDRemoteSystemKindHolographic,
    MCDRemoteSystemKindPhone,
    MCDRemoteSystemKindXbox,
    MCDRemoteSystemKindHub
};

/**
 * @brief Returns string representation for a Remote System Kind.
 * @param MCDRemoteSystemKind The kind.
 * @returns String representation.
 */
__MCD_VISIBLE_EXTERNALLY
NSString* MCDRemoteSystemFriendlyNameForKind(MCDRemoteSystemKind type);