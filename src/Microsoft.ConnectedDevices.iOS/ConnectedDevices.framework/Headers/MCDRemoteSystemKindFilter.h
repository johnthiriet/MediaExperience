//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MCDCommon.h"
#import "MCDRemoteSystemKind.h"
#import "MCDRemoteSystemFilter.h"

/**
 * @brief A class used to filter discovery based upon Remote System kinds.
 */
__MCD_VISIBLE_EXTERNALLY
@interface MCDRemoteSystemKindFilter : NSObject<MCDRemoteSystemFilter>

/**
 * @brief Initializes the filter with an array of kinds to match for.
 * @param kinds The array of kinds.
 * @returns The initialized filter, otherwise nil.
 */
-(nullable instancetype)initWithKindsArray:(nonnull NSArray*)kinds;

@end
