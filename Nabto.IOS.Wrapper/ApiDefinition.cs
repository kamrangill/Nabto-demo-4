using System;

using ObjCRuntime;
using Foundation;
using UIKit;
using Nabto.IOS.Wrapper;

namespace Nabto.IOS.Wrapper
{
    // The first step to creating a binding is to add your native library ("libNativeLibrary.a")
    // to the project by right-clicking (or Control-clicking) the folder containing this source
    // file and clicking "Add files..." and then simply select the native library (or libraries)
    // that you want to bind.
    //
    // When you do that, you'll notice that MonoDevelop generates a code-behind file for each
    // native library which will contain a [LinkWith] attribute. VisualStudio auto-detects the
    // architectures that the native library supports and fills in that information for you,
    // however, it cannot auto-detect any Frameworks or other system libraries that the
    // native library may depend on, so you'll need to fill in that information yourself.
    //
    // Once you've done that, you're ready to move on to binding the API...
    //
    //
    // Here is where you'd define your API definition for the native Objective-C library.
    //
    // For example, to bind the following Objective-C class:
    //
    //     @interface Widget : NSObject {
    //     }
    //
    // The C# binding would look like this:
    //
    //     [BaseType (typeof (NSObject))]
    //     interface Widget {
    //     }
    //
    // To bind Objective-C properties, such as:
    //
    //     @property (nonatomic, readwrite, assign) CGPoint center;
    //
    // You would add a property definition in the C# interface like so:
    //
    //     [Export ("center")]
    //     CGPoint Center { get; set; }
    //
    // To bind an Objective-C method, such as:
    //
    //     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
    //
    // You would add a method definition to the C# interface like so:
    //
    //     [Export ("doSomething:atIndex:")]
    //     void DoSomething (NSObject object, int index);
    //
    // Objective-C "constructors" such as:
    //
    //     -(id)initWithElmo:(ElmoMuppet *)elmo;
    //
    // Can be bound as:
    //
    //     [Export ("initWithElmo:")]
    //     IntPtr Constructor (ElmoMuppet elmo);
    //
    // For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_types
    //

    // @interface NabtoClient : NSObject
    [BaseType(typeof(NSObject))]
    public interface NabtoClient
    {

        // -(nabto_status_t)nabtoStartup;
        [Export("nabtoStartup")]
        nabto_status_t Startup { get; }

        // -(nabto_status_t)nabtoShutdown;
        [Export("nabtoShutdown")]
        nabto_status_t Shutdown();
        // -(NSString *)nabtoVersion;
        [Export("nabtoVersion")]
        //[Verify(MethodToProperty)]
         string Version { get; }

        // -(nabto_status_t)nabtoCreateSelfSignedProfile:(NSString *)email withPassword:(NSString *)password;
        [Export("nabtoCreateSelfSignedProfile:withPassword:")]
         nabto_status_t CreateSelfSignedProfile(string email, string password);

        // -(nabto_status_t)nabtoGetFingerprint:(NSString *)certificateId withResult:(char *)result;
        [Export("nabtoGetFingerprint:withResult:")]
          nabto_status_t GetFingerprint(string certificateId, byte result);

        // -(nabto_status_t)nabtoOpenSession:(NSString *)email withPassword:(NSString *)password;
        [Export("nabtoOpenSession:withPassword:")]
          nabto_status_t OpenSession(string email, string password);

        // -(nabto_status_t)nabtoOpenSessionGuest;
        [Export("nabtoOpenSessionGuest")]
        // [Verify(MethodToProperty)]
        nabto_status_t OpenSessionGuest();

        // -(nabto_status_t)nabtoCloseSession;
        [Export("nabtoCloseSession")]
        //  [Verify(MethodToProperty)]
        nabto_status_t CloseSession();

        // -(nabto_status_t)nabtoFetchUrl:(NSString *)url withResultBuffer:(char **)resultBuffer resultLength:(size_t *)resultLength mimeType:(char **)mimeType;
        [Export("nabtoFetchUrl:withResultBuffer:resultLength:mimeType:")]
       unsafe  nabto_status_t FetchUrl(string url,   byte resultBuffer, ref nuint resultLength,  byte mimeType);

        // -(nabto_status_t)nabtoSubmitPostData:(NSString *)url withBuffer:(NSString *)postBuffer resultBuffer:(char **)resultBuffer resultLength:(size_t *)resultLen mimeType:(char **)mimeType;
        [Export("nabtoSubmitPostData:withBuffer:resultBuffer:resultLength:mimeType:")]
        unsafe nabto_status_t SubmitPostData(string url, string postBuffer, ref byte resultBuffer, ref nuint resultLen, ref byte mimeType);

        // -(nabto_status_t)nabtoRpcInvoke:(NSString *)url withResultBuffer:(char **)jsonResponse;
        [Export("nabtoRpcInvoke:withResultBuffer:")]
        unsafe nabto_status_t RpcInvoke(string url, ref byte jsonResponse);

        // -(nabto_status_t)nabtoRpcSetDefaultInterface:(NSString *)interfaceDefinition withErrorMessage:(char **)errorMessage;
        [Export("nabtoRpcSetDefaultInterface:withErrorMessage:")]
        unsafe nabto_status_t RpcSetDefaultInterface(string interfaceDefinition, ref byte errorMessage);

        // -(nabto_status_t)nabtoRpcSetInterface:(NSString *)host withInterfaceDefinition:(NSString *)interfaceDefinition withErrorMessage:(char **)errorMessage;
        [Export("nabtoRpcSetInterface:withInterfaceDefinition:withErrorMessage:")]
        unsafe nabto_status_t RpcSetInterface(string host, string interfaceDefinition, ref byte errorMessage);

        // -(NSArray *)nabtoGetLocalDevices;
        [Export("nabtoGetLocalDevices")]
     // [Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NSObject[] GetLocalDevices { get; }

        // -(NSString *)nabtoGetSessionToken;
        [Export("nabtoGetSessionToken")]
     //   [Verify(MethodToProperty)]
        string GetSessionToken { get; }

        // -(nabto_status_t)nabtoTunnelOpenTcp:(nabto_tunnel_t *)handle toHost:(NSString *)host onPort:(int)port;
        [Export("nabtoTunnelOpenTcp:toHost:onPort:")]
        unsafe nabto_status_t TunnelOpenTcp(ref nabto_tunnel_t handle, string host, int port);

        // -(int)nabtoTunnelVersion:(nabto_tunnel_t)handle;
        [Export("nabtoTunnelVersion:")]
        unsafe int TunnelVersion(ref nabto_tunnel_t handle);

        // -(nabto_tunnel_state_t)nabtoTunnelInfo:(nabto_tunnel_t)handle;
        [Export("nabtoTunnelInfo:")]
        unsafe nabto_tunnel_state_t TunnelInfo(nabto_tunnel_t handle);

        // -(nabto_status_t)nabtoTunnelError:(nabto_tunnel_t)handle;
        [Export("nabtoTunnelError:")]
        unsafe nabto_status_t TunnelError(ref nabto_tunnel_t handle);

        // -(int)nabtoTunnelPort:(nabto_tunnel_t)handle;
        [Export("nabtoTunnelPort:")]
        unsafe int TunnelPort(ref nabto_tunnel_t handle);

        // -(nabto_status_t)nabtoTunnelClose:(nabto_tunnel_t)handle;
        [Export("nabtoTunnelClose:")]
        unsafe nabto_status_t TunnelClose(ref nabto_tunnel_t handle);

        // -(nabto_status_t)nabtoFree:(void *)p;
        //[Export("nabtoFree:")]
//unsafe nabto_status_t NabtoFree(ref void* p);

        // +(id)instance;
        [Static]
        [Export("instance")]
      //  [Verify(MethodToProperty)]
        NSObject Instance { get; }

        // +(NSString *)nabtoStatusString:(nabto_status_t)status;
        [Static]
        [Export("nabtoStatusString:")]
        string StatusString(nabto_status_t status);

        // +(NSString *)nabtoTunnelInfoString:(nabto_tunnel_state_t)status;
        [Static]
        [Export("nabtoTunnelInfoString:")]
        string TunnelInfoString(nabto_tunnel_state_t status);


        /**
 * Definition of the callback function for the nabtoRegisterLogCallback
 * function. This should use the NABTOAPI calling convention in the future.
 * @param line     The line to log.
 * @param size     The length of the line.
 */
        //typedef void (*NabtoLogCallbackFunc)(const char* line, size_t size);

    //    [Export("NabtoLogCallbackFunc:")]
       // void NabtoLogCallbackFunc(string line, UIntPtr size);


        /**
 * DEPRECATED: HTML DD based application are deprecated, use
 * rpcInvoke instead (but no async version exists yet)
 */
     /*   typedef void (NABTOAPI* NabtoAsyncStatusCallbackFunc)(nabto_async_status_t status,
                                                      void* arg,
                                                      void* userData);
       */
       //[Export("animation:valueForProgress:"), DelegateName("NSAnimationProgress"), DefaultValueFromArgumentAttribute("progress")]
        //float ComputeAnimationCurve(NSAnimation animation, float progress);

        ////[Export("webViewDidFinishLoad:"), EventArgs("UIWebView"), EventName("LoadFinished")]
        ////void LoadingFinished(UIWebView webView);

   //     [Export("NabtoAsyncStatusCallbackFunc:")]
     //   void NabtoAsyncStatusCallbackFunc(nabto_async_status_t status, NSObject arg , NSObject UserData);
    }

}

