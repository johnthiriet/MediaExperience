//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MCDCommon.h"

/**
 * @brief A class to represent options passed when launching a URI against a Remote System.
 */
__MCD_VISIBLE_EXTERNALLY
@interface MCDRemoteLauncherOptions : NSObject <NSCopying>

/**
 * @brief The fallback uri.
 */
@property (nonatomic, copy, nullable) NSString* fallbackUri;

/**
 * @brief The app ids.
 */
@property (nonatomic, copy, nullable) NSArray* preferredAppIds;

@end
