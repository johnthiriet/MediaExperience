
//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

#import "MCDClientIdentityProviderDelegate.h"

typedef void (^MCDAuthCodeCallback)(NSError* _Nullable error, NSString* _Nullable accessCode);

/**
 * @brief A protocol for returning OAuth Access Code.
 */
__MCD_VISIBLE_EXTERNALLY
@protocol MCDOAuthCodeProviderDelegate <MCDClientIdentityProviderDelegate>

/**
 * @brief Asynchronously obtains a new OAuth access code.
 * @param signInUri The URI which should be shown in a WebView.
 * @param completion Callback which should be invoked when the OAuth access code is obtained or an error occurs.
 * @return An error if there was a failure preparing the async request.
 */
- (nullable NSError*)getAccessCode:(nonnull NSString*)signInUri completion:(nullable MCDAuthCodeCallback)completion;

@end
