//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MCDCommon.h"
#import "MCDRemoteSystemStatusType.h"
#import "MCDRemoteSystemFilter.h"

/**
 * @brief A class used which represents a filter based upon status type.
 */
__MCD_VISIBLE_EXTERNALLY
@interface MCDRemoteSystemStatusTypeFilter : NSObject<MCDRemoteSystemFilter>

-(nullable instancetype)init __attribute__((unavailable("init not available. Please use initWithStatusType.")));

/**
 * @brief Initializes the filter with a status type.
 * @pargm statusType The desired status type.
 * @returns The initialized filter, otherwise nil.
 */
-(nullable instancetype)initWithStatusType:(MCDRemoteSystemStatusType)statusType;

/**
 * @brief The status type.
 */
@property (nonatomic, readonly)MCDRemoteSystemStatusType type;

@end
