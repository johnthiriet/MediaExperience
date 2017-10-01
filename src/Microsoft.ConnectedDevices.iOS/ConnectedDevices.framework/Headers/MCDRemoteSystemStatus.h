//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

/** @brief The status of a Remote System. */
typedef NS_ENUM(NSInteger, MCDRemoteSystemStatus) {
    /** @brief The status of the Remote System is unknown. */
    MCDRemoteSystemStatusUnknown = 0,
    /** @brief The status of the Remote System is still being determined. */
    MCDRemoteSystemStatusDiscoveringAvailability,
    /** @brief The Remote System is reported as being available. */
    MCDRemoteSystemStatusAvailable,
    /** @brief The Remote System is reported as being unavailable. */
    MCDRemoteSystemStatusUnavailable
};
