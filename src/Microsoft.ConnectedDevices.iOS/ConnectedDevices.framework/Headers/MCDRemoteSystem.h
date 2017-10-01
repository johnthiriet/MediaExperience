//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MCDCommon.h"
#import "MCDRemoteSystemStatus.h"
#import "MCDRemoteSystemKind.h"

/**
 * @brief A class to represent a Remote System.
 */
__MCD_VISIBLE_EXTERNALLY
@interface MCDRemoteSystem : NSObject

-(nullable instancetype)init __attribute__((unavailable("init not available. A MCDRemoteSystem can only be created by the framework internally.")));

/**
 * @brief The identifier for this Remote System.
 */
@property (nonatomic, readonly, copy, nonnull) NSString* id;

/**
 * @brief The friendly display name of this Remote System.
 */
@property (nonatomic, readonly, copy, nonnull) NSString* displayName;

/**
 * @brief The deduplication hint of this Remote System. Not guaranteed to be set or unique.
 */
@property (nonatomic, readonly, copy, nonnull) NSString* deduplicationHint DEPRECATED_ATTRIBUTE;

/**
 * @brief The resources associated with this remote system.
 */
@property (nonatomic, readonly, copy, nonnull) NSArray* resources DEPRECATED_ATTRIBUTE;

/**
 * @brief The kind of this Remote System.
 */
@property (nonatomic, readonly) MCDRemoteSystemKind kind;

/**
 * @brief Whether the RemoteSystem can be connected over proximally (UDP or Bluetooth)
 */
@property (nonatomic, readonly) BOOL isAvailableByProximity;

/**
 * @brief The availablity of this Remote System.
 */
@property (nonatomic, readonly) MCDRemoteSystemStatus status;

@end
