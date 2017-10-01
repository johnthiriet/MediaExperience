//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

typedef NS_ENUM(NSInteger, MCDRemoteSystemDiscoveryType) {
	/** @brief The Remote System should be available over the cloud. */
    MCDRemoteSystemDiscoveryTypeCloud = 1,
    /** @brief The Remote System should be available proximally. */
    MCDRemoteSystemDiscoveryTypeProximal = 1 << 1,
    /** @brief The Remote System should be available over any transport. */
    MCDRemoteSystemDiscoveryTypeAny = 0xFFFF,
};
