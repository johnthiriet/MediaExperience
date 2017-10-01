//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MCDCommon.h"
#import "MCDRemoteSystemConnectionRequest.h"
#import "MCDRemoteSystemDiscoveryManagerDelegate.h"
#import "MCDRemoteLauncherUriStatus.h"
#import "MCDRemoteLauncherOptions.h"

/**
 * @brief A class used to launch URIs on Remote Systems.
 */
__MCD_VISIBLE_EXTERNALLY
@interface MCDRemoteLauncher : NSObject

-(nullable instancetype) init __attribute__((unavailable("init not available.")));

/**
 * @brief Launches a URI against the Remote System specified in the Connection Request.
 * @param uri The URI to launch.
 * @param request The Connection Request.
 * @param completion The callback invoked when the request suceeds or fails.
 */
+(void)launchUri:(nonnull NSString*)uri withRequest:(nonnull MCDRemoteSystemConnectionRequest*)request 
                                            withCompletion:(nullable void (^)(MCDRemoteLauncherUriStatus))completion;

/**
 * @brief Launches a URI with options against the Remote System specified in the Connection Request
 *
 * @param uri The URI to launch.
 * @param request The Connection Request.
 * @param options The launcher options.
 * @param completion The block to invoke when the async request either succeeds or fails.
 */
+(void)launchUri:(nonnull NSString*)uri withRequest:(nonnull MCDRemoteSystemConnectionRequest*)request 
                                            withOptions:(nonnull MCDRemoteLauncherOptions*)options 
                                            withCompletion:(nonnull void (^)(MCDRemoteLauncherUriStatus))completion;

@end
