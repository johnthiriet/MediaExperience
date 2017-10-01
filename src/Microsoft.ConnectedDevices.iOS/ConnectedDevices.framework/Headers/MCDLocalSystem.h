//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MCDCommon.h"

/**
 * @brief A class to represent the local system.
 */
__MCD_VISIBLE_EXTERNALLY
DEPRECATED_ATTRIBUTE
@interface MCDLocalSystem : NSObject

-(nullable instancetype)init __attribute__((unavailable("init not available. A MCDLocalSystem can only be created by the framework internally.")));

+(void)registerCapability:(nonnull NSString*)capability completion:(void (^ _Nullable)(NSError* _Nullable))completion DEPRECATED_ATTRIBUTE;

/**
 * @brief The device thumbprint provided by this system.
 */
+(nonnull NSString*)deviceThumbprint;

/**
 * @brief The deduplication hint provided by this system. Not guaranteed to be unique.
 */
+(nonnull NSString*)deduplicationHint DEPRECATED_ATTRIBUTE;

@end
