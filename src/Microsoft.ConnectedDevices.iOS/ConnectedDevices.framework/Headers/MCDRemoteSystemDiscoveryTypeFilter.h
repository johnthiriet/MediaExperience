//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MCDCommon.h"
#import "MCDRemoteSystemDiscoveryType.h"
#import "MCDRemoteSystemFilter.h"

/**
 * @brief A class used to filter discovery based upon discovery type.
 */
__MCD_VISIBLE_EXTERNALLY
@interface MCDRemoteSystemDiscoveryTypeFilter : NSObject<MCDRemoteSystemFilter>

-(nullable instancetype)init __attribute__((unavailable("init not available. Please use initWithKind.")));

/**
 * @brief Initializes the filter with a discovery type.
 * @param initType The discovery type.
 * @returns The initialized filter, otherwise nil.
 */
-(nullable instancetype)initWithType:(MCDRemoteSystemDiscoveryType)initType;

/**
 * @brief The type.
 */
@property (nonatomic, readonly)MCDRemoteSystemDiscoveryType type;

@end
