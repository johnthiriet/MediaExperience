//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MCDCommon.h"

/**
 * @brief A class to represent an application resource
 */
__MCD_VISIBLE_EXTERNALLY
@interface MCDResource : NSObject

-(nullable instancetype)init __attribute__((unavailable("init not available. A MCDResource can only be created by the framework internally.")));

/**
 * @brief The identifier for this resource.
 */
@property (nonatomic, readonly, copy) NSString* _Nullable id;


/**
 * @brief The URL for this resource.
 */
@property (nonatomic, readonly, copy) NSString* _Nullable url;


/**
 * @brief The value of this resource.
 */
@property (nonatomic, readonly, copy) NSString* _Nullable value;

@end
