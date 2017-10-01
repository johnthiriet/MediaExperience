
//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

#import "MCDClientIdentityProviderDelegate.h"

typedef void (^MCDRefreshTokenCallback)(NSError* _Nullable error, NSString* _Nullable refreshToken);

/**
 * @brief A protocol for returning OAuth Refresh Tokens.
 */
__MCD_VISIBLE_EXTERNALLY
@protocol MCDRefreshTokenProviderDelegate <MCDClientIdentityProviderDelegate>

/**
 * @brief Asynchronously obtains a new Refresh Token
 * @param completion Callback which should be invoked when the OAuth refresh token is obtained or an error occurs.
 *  Should be saved and called whenever a new refresh token is available to provide platform with updated token.
 * @return An error if there was a failure preparing the async request.
 */
- (nullable NSError*)getRefreshToken:(nullable MCDRefreshTokenCallback)completion;

@end
