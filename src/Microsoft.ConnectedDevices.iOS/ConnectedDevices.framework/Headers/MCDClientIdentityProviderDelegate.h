
//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

#import "MCDCommon.h"

/**
 * @brief A protocol for returning OAuth Client ID
 */
__MCD_VISIBLE_EXTERNALLY
@protocol MCDClientIdentityProviderDelegate

/**
 * @brief Client ID that represents the current application.
 */
@property(nonatomic, readonly, copy, nonnull) NSString* clientId;

@end
