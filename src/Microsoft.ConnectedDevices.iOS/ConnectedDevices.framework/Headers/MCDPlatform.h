//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

#import "MCDCommon.h"
#import "MCDOAuthCodeProviderDelegate.h"
#import "MCDRefreshTokenProviderDelegate.h"

/**
 * @brief A static class to perform global scale commands to the Rome Platform.
 */
__MCD_VISIBLE_EXTERNALLY
@interface MCDPlatform : NSObject

/**
 * @brief Asynchronously initializes the Rome Platform.
 * This must be called with a successful completion before other parts of the framework can be invoked.
 * @param delegate The delegate which provides an OAuthCode.
 * @param completion Callback invoked when the platform has attempted initialization. Sucessful when error is nil.
 */
+ (void)startWithOAuthCodeProviderDelegate:(id<MCDOAuthCodeProviderDelegate>)delegate completion:(void (^)(NSError* error))completion;

/**
 * @brief Asynchronously initializes the Rome Platform.
 * This must be called with a successful completion before other parts of the framework can be invoked.
 * @param delegate The delegate which provides a Refresh Token.
 * @param completion Callback invoked when the platform has attempted initialization. Sucessful when error is nil.
 */
+ (void)startWithRefreshTokenProviderDelegate:(id<MCDRefreshTokenProviderDelegate>)delegate completion:(void (^)(NSError* error))completion;

/**
 * @brief Suspends the Rome Platform.
 * This should be called when your app is sent to the background.
 */
+ (void)suspend;

/**
 * @brief Resumes the Rome platform.
 * This should be called when your app enters the foreground.
 */
+ (void)resume;

/**
 * @brief Shutdowns the Rome Platform.
 * This should be called when your app is exiting or you want to forcefully stop the platform.
 */
+ (void)shutdown;

@end
