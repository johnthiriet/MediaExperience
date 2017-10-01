using System;
using Foundation;
using ObjCRuntime;

namespace Microsoft.ConnectedDevices
{
    [Static]
    //[Verify (ConstantsInterfaceAssociation)]
    partial interface Constants
    {
    	// extern double ContinuumVersionNumber;
    	[Field ("ContinuumVersionNumber", "__Internal")]
    	double ContinuumVersionNumber { get; }

    	// extern const unsigned char [] ContinuumVersionString;
    	[Field ("ContinuumVersionString", "__Internal")]
    	NSString ContinuumVersionString { get; }
    }

    // @interface MCDRemoteSystem : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MCDRemoteSystem
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull id;
        [Export("id")]
        string Id { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull displayName;
        [Export("displayName")]
        string DisplayName { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull deduplicationHint __attribute__((deprecated("")));
        [Export("deduplicationHint")]
        string DeduplicationHint { get; }

        // @property (readonly, copy, nonatomic) NSArray * _Nonnull resources __attribute__((deprecated("")));
        [Export("resources", ArgumentSemantic.Copy)]
        NSObject[] Resources { get; }

        // @property (readonly, nonatomic) MCDRemoteSystemKind kind;
        [Export ("kind")]
        MCDRemoteSystemKind Kind { get; }

        // @property (readonly, nonatomic) BOOL isAvailableByProximity;
        [Export("isAvailableByProximity")]
        bool IsAvailableByProximity { get; }

        // @property (readonly, nonatomic) MCDRemoteSystemStatus status;
        [Export ("status")]
        MCDRemoteSystemStatus Status { get; }

		// @property (readonly, nonatomic) BOOL isConnected;
		[Export("isConnected")]
		bool IsConnected { get; }
    }

    // @protocol MCDRemoteSystemDiscoveryManagerDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface MCDRemoteSystemDiscoveryManagerDelegate
    {
    	// @optional -(void)remoteSystemDiscoveryManager:(MCDRemoteSystemDiscoveryManager * _Nonnull)discoveryManager didFind:(MCDRemoteSystem * _Nonnull)remoteSystem;
    	[Export ("remoteSystemDiscoveryManager:didFind:")]
    	void RemoteSystemDiscoveryManagerDidFind (MCDRemoteSystemDiscoveryManager discoveryManager, MCDRemoteSystem remoteSystem);

    	// @optional -(void)remoteSystemDiscoveryManager:(MCDRemoteSystemDiscoveryManager * _Nonnull)discoveryManager didRemove:(MCDRemoteSystem * _Nonnull)remoteSystem;
    	[Export ("remoteSystemDiscoveryManager:didRemove:")]
    	void RemoteSystemDiscoveryManagerDidRemove (MCDRemoteSystemDiscoveryManager discoveryManager, MCDRemoteSystem remoteSystem);

    	// @optional -(void)remoteSystemDiscoveryManager:(MCDRemoteSystemDiscoveryManager * _Nonnull)discoveryManager didUpdate:(MCDRemoteSystem * _Nonnull)remoteSystem;
    	[Export ("remoteSystemDiscoveryManager:didUpdate:")]
    	void RemoteSystemDiscoveryManagerDidUpdate (MCDRemoteSystemDiscoveryManager discoveryManager, MCDRemoteSystem remoteSystem);

    	// @optional -(void)remoteSystemDiscoveryManagerDidComplete:(MCDRemoteSystemDiscoveryManager * _Nonnull)discoveryManager withError:(NSError * _Nullable)error;
    	[Export ("remoteSystemDiscoveryManagerDidComplete:withError:")]
    	void RemoteSystemDiscoveryManagerDidComplete (MCDRemoteSystemDiscoveryManager discoveryManager, [NullAllowed] NSError error);
    }

    // @interface MCDRemoteSystemConnectionRequest : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MCDRemoteSystemConnectionRequest
    {
        // -(instancetype _Nullable)initWithRemoteSystem:(MCDRemoteSystem * _Nonnull)remoteSystem;
        [Export("initWithRemoteSystem:")]
        IntPtr Constructor(MCDRemoteSystem remoteSystem);

        // @property (readonly, nonatomic, strong) MCDRemoteSystem * _Nonnull remoteSystem;
        [Export("remoteSystem", ArgumentSemantic.Strong)]
        MCDRemoteSystem RemoteSystem { get; }
    }

    // @interface MCDAppServiceClientResponse : NSObject
    [BaseType (typeof(NSObject))]
    interface MCDAppServiceClientResponse
    {
    	// @property (readonly, copy, nonatomic) NSDictionary * _Nullable message;
    	[NullAllowed, Export ("message", ArgumentSemantic.Copy)]
    	NSDictionary Message { get; }

    	// @property (readonly, nonatomic) MCDAppServiceResponseStatus status;
    	[Export ("status")]
    	MCDAppServiceResponseStatus Status { get; }

    	// -(instancetype _Nullable)initWithDictionary:(NSDictionary * _Nonnull)dictionary status:(MCDAppServiceResponseStatus)status;
    	[Export ("initWithDictionary:status:")]
    	IntPtr Constructor (NSDictionary dictionary, MCDAppServiceResponseStatus status);
    }

    // @protocol MCDAppServiceClientConnectionManagerDelegate <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface MCDAppServiceClientConnectionManagerDelegate
    {
    	// @optional -(void)appServiceClientConnectionManagerDidOpen:(MCDAppServiceClientConnectionManager * _Nonnull)manager;
    	[Export ("appServiceClientConnectionManagerDidOpen:")]
    	void AppServiceClientConnectionManagerDidOpen (MCDAppServiceClientConnectionManager manager);

    	// @optional -(void)appServiceClientConnectionManager:(MCDAppServiceClientConnectionManager * _Nonnull)manager didFail:(MCDAppServiceClientConnectionStatus)status;
    	[Export ("appServiceClientConnectionManager:didFail:")]
    	void AppServiceClientConnectionManager (MCDAppServiceClientConnectionManager manager, MCDAppServiceClientConnectionStatus status);

    	// @optional -(void)appServiceClientConnectionManager:(MCDAppServiceClientConnectionManager * _Nonnull)manager didClose:(MCDAppServiceClientClosedStatus)status;
    	[Export ("appServiceClientConnectionManager:didClose:")]
    	void AppServiceClientConnectionManager (MCDAppServiceClientConnectionManager manager, MCDAppServiceClientClosedStatus status);

    	// @optional -(void)appServiceClientConnectionManager:(MCDAppServiceClientConnectionManager * _Nonnull)manager didReceiveResponse:(MCDAppServiceClientResponse * _Nonnull)response;
    	[Export ("appServiceClientConnectionManager:didReceiveResponse:")]
    	void AppServiceClientConnectionManager (MCDAppServiceClientConnectionManager manager, MCDAppServiceClientResponse response);
    }

    // @interface MCDAppServiceClientConnectionManager : NSObject
    [BaseType (typeof(NSObject))]
    [DisableDefaultCtor]
    interface MCDAppServiceClientConnectionManager
    {
    	[Wrap ("WeakDelegate")]
    	[NullAllowed]
    	MCDAppServiceClientConnectionManagerDelegate Delegate { get; }

    	// @property (readonly, nonatomic, weak) id<MCDAppServiceClientConnectionManagerDelegate> _Nullable delegate;
    	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
    	NSObject WeakDelegate { get; }

    	// @property (readonly, nonatomic, strong) MCDRemoteSystemConnectionRequest * _Nonnull connectionRequest;
    	[Export ("connectionRequest", ArgumentSemantic.Strong)]
    	MCDRemoteSystemConnectionRequest ConnectionRequest { get; }

    	// @property (readonly, copy, nonatomic) NSString * _Nonnull appServiceName;
    	[Export ("appServiceName")]
    	string AppServiceName { get; }

    	// @property (readonly, copy, nonatomic) NSString * _Nonnull appIdentifier;
    	[Export ("appIdentifier")]
    	string AppIdentifier { get; }

    	// -(instancetype _Nullable)initWithConnectionRequest:(MCDRemoteSystemConnectionRequest * _Nonnull)request appServiceName:(NSString * _Nonnull)appServiceName appIdentifier:(NSString * _Nonnull)appIdentifier delegate:(id<MCDAppServiceClientConnectionManagerDelegate> _Nonnull)delegate;
    	[Export ("initWithConnectionRequest:appServiceName:appIdentifier:delegate:")]
    	IntPtr Constructor (MCDRemoteSystemConnectionRequest request, string appServiceName, string appIdentifier, MCDAppServiceClientConnectionManagerDelegate @delegate);

        // -(NSError * _Nullable)close;
        [NullAllowed, Export("close")]
        NSError Close();

    	// -(void)openRemote;
    	[Export ("openRemote")]
    	void OpenRemote ();

    	// -(void)sendMessage:(NSDictionary * _Nonnull)dictionary;
    	[Export ("sendMessage:")]
    	void SendMessage (NSDictionary dictionary);
    }

    // @interface MCDLocalSystem : NSObject
    [BaseType (typeof(NSObject))]
    [DisableDefaultCtor]
    interface MCDLocalSystem
    {
    	// +(void)registerCapability:(NSString * _Nonnull)capability completion:(void (^ _Nullable)(NSError * _Nullable))completion __attribute__((deprecated("")));
    	[Static]
    	[Export ("registerCapability:completion:")]
    	void RegisterCapability (string capability, [NullAllowed] Action<NSError> completion);

    	// +(NSString * _Nonnull)deviceThumbprint;
    	[Static]
    	[Export ("deviceThumbprint")]
    	string DeviceThumbprint { get; }

    	// +(NSString * _Nonnull)deduplicationHint __attribute__((deprecated("")));
    	[Static]
    	[Export ("deduplicationHint")]
    	string DeduplicationHint { get; }
    }

    // @protocol MCDClientIdentityProviderDelegate
    [Protocol, Model]
    public interface IMCDClientIdentityProviderDelegate
    {
    	// @required @property (readonly, copy, nonatomic) NSString * _Nonnull clientId;
    	[Abstract]
    	[Export ("clientId")]
    	string ClientId { get; }
    }

    // typedef void (^MCDAuthCodeCallback)(NSError * _Nullable, NSString * _Nullable);
    delegate void MCDAuthCodeCallback ([NullAllowed] NSError error, [NullAllowed] string refreshToken);

    // @protocol MCDOAuthCodeProviderDelegate <MCDClientIdentityProviderDelegate>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface MCDOAuthCodeProviderDelegate : IMCDClientIdentityProviderDelegate
    {
    	// @required -(NSError * _Nullable)getAccessCode:(NSString * _Nonnull)signInUri completion:(MCDAuthCodeCallback _Nullable)completion;
    	[Abstract]
    	[Export ("getAccessCode:completion:")]
    	[return: NullAllowed]
    	NSError Completion (string signInUri, [NullAllowed] MCDAuthCodeCallback completion);
    }

    // typedef void (^MCDRefreshTokenCallback)(NSError * _Nullable, NSString * _Nullable);
    public delegate void MCDRefreshTokenCallback ([NullAllowed] NSError arg0, [NullAllowed] string arg1);

    // @protocol MCDRefreshTokenProviderDelegate <MCDClientIdentityProviderDelegate>
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    public interface MCDRefreshTokenProviderDelegate : IMCDClientIdentityProviderDelegate
    {
    	// @required -(NSError * _Nullable)getRefreshToken:(MCDRefreshTokenCallback _Nullable)completion;
    	[Abstract]
    	[Export ("getRefreshToken:")]
    	[return: NullAllowed]
    	NSError GetRefreshToken ([NullAllowed] MCDRefreshTokenCallback completion);
    }

    // @interface MCDPlatform : NSObject
    [BaseType (typeof(NSObject))]
    interface MCDPlatform
    {
    	// +(void)startWithOAuthCodeProviderDelegate:(id<MCDOAuthCodeProviderDelegate>)delegate completion:(void (^)(NSError *))completion;
    	[Static]
    	[Export ("startWithOAuthCodeProviderDelegate:completion:")]
    	void StartWithOAuthCodeProviderDelegate (MCDOAuthCodeProviderDelegate @delegate, Action<NSError> completion);

    	// +(void)startWithRefreshTokenProviderDelegate:(id<MCDRefreshTokenProviderDelegate>)delegate completion:(void (^)(NSError *))completion;
    	[Static]
    	[Export ("startWithRefreshTokenProviderDelegate:completion:")]
    	void StartWithRefreshTokenProviderDelegate (MCDRefreshTokenProviderDelegate @delegate, Action<NSError> completion);

    	// +(void)suspend;
    	[Static]
    	[Export ("suspend")]
    	void Suspend ();

    	// +(void)resume;
    	[Static]
    	[Export ("resume")]
    	void Resume ();

    	// +(void)shutdown;
    	[Static]
    	[Export ("shutdown")]
    	void Shutdown ();
    }

    // @interface MCDRemoteLauncherOptions : NSObject <NSCopying>
    [BaseType (typeof(NSObject))]
    interface MCDRemoteLauncherOptions : INSCopying
    {
    	// @property (copy, nonatomic) NSString * _Nullable fallbackUri;
    	[NullAllowed, Export ("fallbackUri")]
    	string FallbackUri { get; set; }

    	// @property (copy, nonatomic) NSArray * _Nullable preferredAppIds;
    	[NullAllowed, Export ("preferredAppIds")]
    	//[Verify (StronglyTypedNSArray)]
    	string[] PreferredAppIds { get; set; }
    }

    // @interface MCDRemoteLauncher : NSObject
    [BaseType (typeof(NSObject))]
    [DisableDefaultCtor]
    interface MCDRemoteLauncher
    {
    	// +(void)launchUri:(NSString * _Nonnull)uri withRequest:(MCDRemoteSystemConnectionRequest * _Nonnull)request withCompletion:(void (^ _Nullable)(MCDRemoteLauncherUriStatus))completion;
    	[Static]
    	[Export ("launchUri:withRequest:withCompletion:")]
    	void LaunchUri (string uri, MCDRemoteSystemConnectionRequest request, [NullAllowed] Action<MCDRemoteLauncherUriStatus> completion);

    	// +(void)launchUri:(NSString * _Nonnull)uri withRequest:(MCDRemoteSystemConnectionRequest * _Nonnull)request withOptions:(MCDRemoteLauncherOptions * _Nonnull)options withCompletion:(void (^ _Nonnull)(MCDRemoteLauncherUriStatus))completion;
    	[Static]
    	[Export ("launchUri:withRequest:withOptions:withCompletion:")]
    	void LaunchUri (string uri, MCDRemoteSystemConnectionRequest request, MCDRemoteLauncherOptions options, Action<MCDRemoteLauncherUriStatus> completion);
    }

    // @interface MCDRemoteSystemDiscoveryManager : NSObject
    [BaseType (typeof(NSObject))]
    interface MCDRemoteSystemDiscoveryManager
    {
    	[Wrap ("WeakDelegate")]
    	[NullAllowed]
    	MCDRemoteSystemDiscoveryManagerDelegate Delegate { get; }

    	// @property (readonly, nonatomic, weak) id<MCDRemoteSystemDiscoveryManagerDelegate> _Nullable delegate;
    	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
    	NSObject WeakDelegate { get; }

    	// -(instancetype _Nullable)initWithDelegate:(id<MCDRemoteSystemDiscoveryManagerDelegate> _Nonnull)delegate;
    	[Export ("initWithDelegate:")]
    	IntPtr Constructor (MCDRemoteSystemDiscoveryManagerDelegate @delegate);

    	// -(instancetype _Nullable)initWithDelegate:(id<MCDRemoteSystemDiscoveryManagerDelegate> _Nonnull)delegate withFilters:(NSSet * _Nonnull)filters;
    	[Export ("initWithDelegate:withFilters:")]
    	IntPtr Constructor (MCDRemoteSystemDiscoveryManagerDelegate @delegate, NSSet filters);

    	// -(void)startDiscovery;
    	[Export ("startDiscovery")]
    	void StartDiscovery ();

    	// -(void)startDiscoveryWithHostName:(NSString * _Nonnull)hostname;
    	[Export ("startDiscoveryWithHostName:")]
    	void StartDiscoveryWithHostName (string hostname);

    	// -(void)stopDiscovery;
    	[Export ("stopDiscovery")]
    	void StopDiscovery ();

		[Export("discoverAll")]
		bool DiscoverAll { get; set; }
    }


    // @protocol MCDRemoteSystemFilter
    [BaseType(typeof(NSObject))]
    [Protocol, Model]
    interface IMCDRemoteSystemFilter
    {
    	// @required -(BOOL)matchesRemoteSystem:(MCDRemoteSystem * _Nonnull)remoteSystem;
    	[Abstract]
    	[Export ("matchesRemoteSystem:")]
    	bool MatchesRemoteSystem (MCDRemoteSystem remoteSystem);
    }

    // @interface MCDRemoteSystemDiscoveryTypeFilter : NSObject <MCDRemoteSystemFilter>
    [BaseType (typeof(NSObject))]
    [DisableDefaultCtor]
    interface MCDRemoteSystemDiscoveryTypeFilter : IMCDRemoteSystemFilter
    {
    	// -(instancetype _Nullable)initWithType:(MCDRemoteSystemDiscoveryType)initType;
    	[Export ("initWithType:")]
    	IntPtr Constructor (MCDRemoteSystemDiscoveryType initType);

    	// @property (readonly, nonatomic) MCDRemoteSystemDiscoveryType type;
    	[Export ("type")]
    	MCDRemoteSystemDiscoveryType Type { get; }
    }

    // @interface MCDRemoteSystemKindFilter : NSObject <MCDRemoteSystemFilter>
    [BaseType (typeof(NSObject))]
    interface MCDRemoteSystemKindFilter : IMCDRemoteSystemFilter
    {
    	// -(instancetype _Nullable)initWithKindsArray:(NSArray * _Nonnull)kinds;
    	[Export ("initWithKindsArray:")]
    	IntPtr Constructor (IMCDRemoteSystemFilter[] kinds);
    }

    // @interface MCDResource : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MCDResource
    {
        // @property (readonly, copy, nonatomic) NSString * _Nullable id;
        [NullAllowed, Export("id")]
        string Id { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable url;
        [NullAllowed, Export("url")]
        string Url { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable value;
        [NullAllowed, Export("value")]
        string Value { get; }
    }
}