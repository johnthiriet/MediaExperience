//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MCDCommon.h"
#import "MCDRemoteSystem.h"
#import "MCDRemoteSystemDiscoveryManagerDelegate.h"

/**
 * @brief A class used to find Remote Systems.
 */
__MCD_VISIBLE_EXTERNALLY
@interface MCDRemoteSystemDiscoveryManager : NSObject

/**
 * @brief The delegate which will receive discovery events from this manager.
 */
@property (nonatomic, readonly, weak, nullable)id<MCDRemoteSystemDiscoveryManagerDelegate> delegate;

/**
 * @brief Initializes the instance with the callback delegate.
 * @param delegate The delegate.
 * @returns This instance. Nil on failure.
 */
-(nullable instancetype)initWithDelegate:(nonnull id<MCDRemoteSystemDiscoveryManagerDelegate>)delegate;

/**
 * @brief Initializes the instance with the callback delegate and a set of Remote System Discovery Filters.
 * @param delegate The delegate.
 * @param filters The set of filters.
 * @returns This instance. Nil on failure.
 */
-(nullable instancetype)initWithDelegate:(nonnull id<MCDRemoteSystemDiscoveryManagerDelegate>)delegate withFilters:(nonnull NSSet*)filters;

/**
 * @brief Starts the discovery of Remote Systems. Will restart any existing discovery.
 */
-(void)startDiscovery;

/**
 * @brief Starts the discovery of a Remote System which matches the supplied host name.
 */
-(void)startDiscoveryWithHostName:(nonnull NSString*)hostname;

/**
 * @brief Stops the discovery. No-op if already dropped.
 */
-(void)stopDiscovery;

@end
