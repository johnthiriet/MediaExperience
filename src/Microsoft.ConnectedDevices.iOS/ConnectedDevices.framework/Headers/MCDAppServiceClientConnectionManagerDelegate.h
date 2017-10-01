//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MCDRemoteSystem.h"
#import "MCDAppServiceResponseStatus.h"
#import "MCDAppServiceClientClosedStatus.h"
#import "MCDAppServiceClientConnectionStatus.h"
#import "MCDAppServiceClientResponse.h"

@class MCDAppServiceClientConnectionManager;

@protocol MCDAppServiceClientConnectionManagerDelegate <NSObject>

/**
 * @brief Called when a connection has been established.
 * @param manager The delegating MCDAppServiceClientConnectionManager.
 * @remarks Optional
 */
@optional
-(void)appServiceClientConnectionManagerDidOpen:(nonnull MCDAppServiceClientConnectionManager*)manager;

/**
 * @brief Called when there was a failure communicating with the Remote System.
 * @param manager The delegating MCDAppServiceClientConnectionManager.
 * @param status The new status.
 * @remarks Optional
 */
@optional
-(void)appServiceClientConnectionManager:(nonnull MCDAppServiceClientConnectionManager*)manager didFail:(MCDAppServiceClientConnectionStatus)status;

/**
 * @brief Called when a connection to a Remote System has closed.
 * @param manager The delegating MCDAppServiceClientConnectionManager.
 * @param status The status.
 * @remarks Optional
 */
@optional
-(void)appServiceClientConnectionManager:(nonnull MCDAppServiceClientConnectionManager*)manager didClose:(MCDAppServiceClientClosedStatus)status;

/**
 * @brief Called when the client has received an App Service message from the Remote System.
 * @param manager The delegating MCDAppServiceClientConnectionManager.
 * @param response The incoming message.
 * @remarks Optional
 */
@optional
-(void)appServiceClientConnectionManager:(nonnull MCDAppServiceClientConnectionManager*)manager didReceiveResponse:(nonnull MCDAppServiceClientResponse*)response;

@end
