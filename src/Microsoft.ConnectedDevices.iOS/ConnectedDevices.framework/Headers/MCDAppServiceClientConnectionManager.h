//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MCDRemoteSystemConnectionRequest.h"
#import "MCDAppServiceClientConnectionManagerDelegate.h"

/**
 * @brief A class used to communicate with a Remote System using App Services..
 */
__MCD_VISIBLE_EXTERNALLY
@interface MCDAppServiceClientConnectionManager : NSObject

-(nullable instancetype) init __attribute__((unavailable("init not available. Please use initWithConnectionRequest.")));

@property (nonatomic, readonly, weak, nullable)id<MCDAppServiceClientConnectionManagerDelegate> delegate;

/**
 * @brief The MCDRemoteSystemConnectionRequest.
 */
@property (nonatomic, readonly, strong, nonnull)MCDRemoteSystemConnectionRequest* connectionRequest;

/**
 * @brief The App Service name.
 */
@property (nonatomic, readonly, copy, nonnull) NSString* appServiceName;

/**
 * @brief The App Service Identifier name.
 */
@property (nonatomic, readonly, copy, nonnull) NSString* appIdentifier;

/**
 * @brief Create an instance.
 */
-(nullable instancetype)initWithConnectionRequest:(nonnull MCDRemoteSystemConnectionRequest*)request 
                                    appServiceName:(nonnull NSString*)appServiceName 
                                    appIdentifier:(nonnull NSString*)appIdentifier
                                    delegate:(nonnull id<MCDAppServiceClientConnectionManagerDelegate>)delegate;

/**
 * @brief Closes an open connection if applicable. No-op if already closed.
 */
-(nullable NSError*)close;

/**
 * @brief Openes the remote connection.
 */
-(void)openRemote;

/**
 * @brief Sends a message to the remote device.
 */
-(void)sendMessage:(nonnull NSDictionary*)dictionary;

@end
