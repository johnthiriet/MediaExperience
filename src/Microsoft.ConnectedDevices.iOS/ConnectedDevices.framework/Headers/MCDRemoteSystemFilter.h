//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

#import "MCDCommon.h"
#import "MCDRemoteSystem.h"

__MCD_VISIBLE_EXTERNALLY
@protocol MCDRemoteSystemFilter

/**
 * @brief Checks whether a Remote System is matched by the current filter.
 * @param remoteSystem The Remote System.
 * @returns Whether the filter matches the specified Remote System.
 */
-(BOOL)matchesRemoteSystem:(nonnull MCDRemoteSystem*)remoteSystem;

@end
