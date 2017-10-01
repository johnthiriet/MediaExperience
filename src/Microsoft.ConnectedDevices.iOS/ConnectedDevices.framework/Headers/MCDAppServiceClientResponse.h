//
//  Copyright (c) Microsoft Corporation. All rights reserved.
//

#import "MCDCommon.h"
#import <Foundation/Foundation.h>
#import "MCDAppServiceResponseStatus.h"

__MCD_VISIBLE_EXTERNALLY
@interface MCDAppServiceClientResponse : NSObject

@property (nonatomic, readonly, copy, nullable)NSDictionary* message;

@property (nonatomic, readonly)MCDAppServiceResponseStatus status;

-(nullable instancetype)initWithDictionary:(nonnull NSDictionary*)dictionary status:(MCDAppServiceResponseStatus)status;

@end
