//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

/** @brief The status type of a Remote System. */
typedef NS_ENUM(NSInteger, MCDRemoteSystemStatusType) {
	/** @brief The desired status of the device is available. */
    MCDRemoteSystemStatusTypeAvailable = 0,
    /** @brief The desired status of the device can be any. */
    MCDRemoteSystemStatusTypeAny
};
