//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MCDCommon.h"
#import "MCDRemoteSystem.h"
#import "MCDRemoteSystemDiscoveryManagerDelegate.h"

/**
 * @brief A class used to express a connection request intent against a Remote System.
 */
__MCD_VISIBLE_EXTERNALLY
@interface MCDRemoteSystemConnectionRequest : NSObject

-(nullable instancetype)init __attribute__((unavailable("init not available. Use initWithRemoteSystem.")));

/**
 * @brief Initializes the Connection Request with a Remote System.
 * @param remoteSystem The Remote System.
 */
-(nullable instancetype)initWithRemoteSystem:(nonnull MCDRemoteSystem*)remoteSystem;

/**
 * @brief The Remote System the class was initialized with.
 */
@property (nonatomic, readonly, strong, nonnull)MCDRemoteSystem* remoteSystem;

@end
