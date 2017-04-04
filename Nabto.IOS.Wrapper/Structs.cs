using System;
using System.Runtime.InteropServices;
using Nabto.IOS.Wrapper;

namespace Nabto.IOS.Wrapper
{
   
    public enum nabto_status_t : uint
    {
        Ok = 0,
        NoProfile = 1,
        ErrorReadingConfig = 2,
        ApiNotInitialized = 3,
        InvalidSession = 4,
        OpenCertOrPkFailed = 5,
        UnlockPkFailed = 6,
        PortalLoginFailure = 7,
        CertSigningError = 8,
        CertSavingFailure = 9,
        AddressInUse = 10,
        InvalidAddress = 11,
        NoNetwork = 12,
        ConnectToHostFailed = 13,
        StreamingUnsupported = 14,
        InvalidStream = 15,
        DataPending = 16,
        BufferFull = 17,
        Failed = 18,
        InvalidTunnel = 19,
        IllegalParameter = 20,
        InvalidResource = 21,
        InvalidStreamOption = 22,
        InvalidStreamOptionArgument = 23,
        Aborted = 24,
        StreamClosed = 25,
        FailedWithJsonMessage = 26,
        ErrorCodeCount
    }

    public enum nabto_connection_type_t : uint
    {
        Local = 0,
        P2p = 1,
        Relay = 2,
        Unknown = 3,
        RelayMicro = 4
    }

    public enum nabto_stream_option_t : uint
    {
        Rcvtimeo = 1,
        Sndtimeo = 2
    }

    public enum nabto_tunnel_info_selector_t : uint
    {
        Version = 0,
        Status = 1,
        LastError = 2,
        Port = 3
    }

    public enum nabto_tunnel_state_t
    {
        Closed = -1,
        Connecting = 0,
        ReadyForReconnect = 1,
        Unknown = 2,
        Local = 3,
        RemoteP2p = 4,
        RemoteRelay = 5,
        RemoteRelayMicro = 6
    }


    public enum nabto_async_post_data_status_t : uint
    {
        Ok = 0,
        Closed = 1
    }

    public enum nabto_async_status_t : uint
    {
        MimetypeAvailable = 0,
        ChunkReady = 1,
        Closed = 2
    }
    public static class CFunctions
    {
        // extern nabto_status_t nabtoStartup (const char *nabtoHomeDir);
        [DllImport("__Internal", EntryPoint = "nabtoStartup")]
        //  [Verify(PlatformInvoke)]
        // static extern unsafe nabto_status_t nabtoStartup(sbyte* nabtoHomeDir);
      public  static extern unsafe nabto_status_t Startup(string nabtoHomeDir);
        // extern nabto_status_t nabtoShutdown ();
        [DllImport("__Internal", EntryPoint = "nabtoShutdown")]
        // [Verify(PlatformInvoke)]
        public static extern nabto_status_t Shutdown();

        // extern nabto_status_t nabtoOpenSession (nabto_handle_t *session, const char *id, const char *password);
        [DllImport("__Internal", EntryPoint = "nabtoOpenSession")]
        //  [Verify(PlatformInvoke)]
        //static extern unsafe nabto_status_t nabtoOpenSession(nabto_handle_t** session, sbyte* id, sbyte* password);
        public static extern unsafe nabto_status_t OpenSession(nabto_handle_t session, [MarshalAs(UnmanagedType.LPStr)] string id, [MarshalAs(UnmanagedType.LPStr)] string password);

        // extern nabto_status_t nabtoCloseSession (nabto_handle_t session);
        [DllImport("__Internal",EntryPoint = "nabtoCloseSession")]
        //[Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t CloseSession(nabto_handle_t* session);

        // extern nabto_status_t nabtoVersionString (char **version);
        [DllImport("__Internal", EntryPoint = "nabtoVersionString")]
        // [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t VersionString(sbyte** version);

        // extern nabto_status_t nabtoRpcSetDefaultInterface (nabto_handle_t session, const char *interfaceDefinition, char **errorMessage);
        [DllImport("__Internal")]
        // [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoRpcSetDefaultInterface(nabto_handle_t* session, sbyte* interfaceDefinition, sbyte** errorMessage);

        // extern nabto_status_t nabtoRpcSetInterface (nabto_handle_t session, const char *host, const char *interfaceDefinition, char **errorMessage);
        [DllImport("__Internal")]
        //  [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoRpcSetInterface(nabto_handle_t* session, sbyte* host, sbyte* interfaceDefinition, sbyte** errorMessage);

        // extern nabto_status_t nabtoRpcInvoke (nabto_handle_t session, const char *nabtoUrl, char **jsonResponse);
        [DllImport("__Internal")]
        // [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoRpcInvoke(nabto_handle_t* session, sbyte* nabtoUrl, sbyte** jsonResponse);

        // extern nabto_status_t nabtoStreamOpen (nabto_stream_t *stream, nabto_handle_t session, const char *serverId);
        [DllImport("__Internal")]
        //  [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoStreamOpen(nabto_stream_t** stream, nabto_handle_t* session, sbyte* serverId);

        // extern nabto_status_t nabtoStreamClose (nabto_stream_t stream);
        [DllImport("__Internal")]
        // [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoStreamClose(nabto_stream_t* stream);

        // extern nabto_status_t nabtoStreamRead (nabto_stream_t stream, char **resultBuffer, size_t *resultLen);
        [DllImport("__Internal")]
        //  [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoStreamRead(nabto_stream_t* stream, sbyte** resultBuffer, nuint* resultLen);

        // extern nabto_status_t nabtoStreamReadIntoBuf (nabto_stream_t stream, char *buffer, size_t bufLen, size_t *resultLen);
        [DllImport("__Internal")]
        // [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoStreamReadIntoBuf(nabto_stream_t* stream, sbyte* buffer, nuint bufLen, nuint* resultLen);

        // extern nabto_status_t nabtoStreamWrite (nabto_stream_t stream, const char *buf, size_t len);
        [DllImport("__Internal")]
        // [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoStreamWrite(nabto_stream_t* stream, sbyte* buf, nuint len);

        // extern nabto_status_t nabtoStreamConnectionType (nabto_stream_t stream, nabto_connection_type_t *type);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoStreamConnectionType(nabto_stream_t* stream, nabto_connection_type_t* type);

        // extern nabto_status_t nabtoStreamSetOption (nabto_stream_t stream, nabto_stream_option_t optionName, const void *optionValue, size_t optionLength);
        [DllImport("__Internal")]
        //  [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoStreamSetOption(nabto_stream_t* stream, nabto_stream_option_t optionName, void* optionValue, nuint optionLength);

        // extern nabto_status_t nabtoTunnelOpenTcp (nabto_tunnel_t *tunnel, nabto_handle_t session, int localPort, const char *nabtoHost, const char *remoteHost, int remotePort);
        [DllImport("__Internal")]
        // [Verify(PlatformInvoke)]
        public  static extern unsafe nabto_status_t nabtoTunnelOpenTcp(nabto_tunnel_t tunnel, nabto_handle_t session, int localPort,  string nabtoHost,  string remoteHost, int remotePort);

        // extern nabto_status_t nabtoTunnelClose (nabto_tunnel_t tunnel);
        [DllImport("__Internal")]
        //  [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoTunnelClose(nabto_tunnel_t tunnel);

        // extern nabto_status_t nabtoTunnelInfo (nabto_tunnel_t tunnel, nabto_tunnel_info_selector_t index, size_t size, void *info);
        [DllImport("__Internal")]
        // [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoTunnelInfo(nabto_tunnel_t tunnel, nabto_tunnel_info_selector_t index, nuint size, void* info);

        // extern nabto_status_t nabtoCreateProfile (const char *email, const char *password);
        [DllImport("__Internal")]
        // [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoCreateProfile(sbyte* email, sbyte* password);

        // extern nabto_status_t nabtoCreateSelfSignedProfile (const char *commonName, const char *password);
        [DllImport("__Internal")]
        // [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoCreateSelfSignedProfile(string commonName, string password);

        // extern nabto_status_t nabtoGetFingerprint (const char *certId, char *fingerprint);
        [DllImport("__Internal")]
        public static extern unsafe nabto_status_t nabtoGetFingerprint(sbyte* certId, sbyte[] fingerprint);

        // extern nabto_status_t nabtoRegisterLogCallback (NabtoLogCallbackFunc callback);


        // This declares the callback signature for the block:
        public delegate void NabtoLogCallbackFunc([MarshalAs(UnmanagedType.LPStr)] string Line, IntPtr size);

         [DllImport("__Internal")]
        public static extern unsafe nabto_status_t nabtoRegisterLogCallback(NabtoLogCallbackFunc callback);
       
        // static extern unsafe nabto_status_t nabtoRegisterLogCallbackAsync();


        // extern const char * nabtoStatusStr (nabto_status_t status);
        [DllImport("__Internal")]
        // [Verify(PlatformInvoke)]
        public static extern unsafe sbyte* nabtoStatusStr(nabto_status_t status);

        // extern nabto_status_t nabtoGetProtocolPrefixes (char ***prefixes, int *prefixesLength);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoGetProtocolPrefixes(sbyte*** prefixes, int* prefixesLength);

        // extern nabto_status_t nabtoGetCertificates (char ***certificates, int *certificatesLength);
        [DllImport("__Internal")]
        // [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoGetCertificates(sbyte*** certificates, int* certificatesLength);

        // extern nabto_status_t nabtoGetLocalDevices (char ***devices, int *numberOfDevices);
        [DllImport("__Internal")]
        //  [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoGetLocalDevices(sbyte*** devices, int* numberOfDevices);

        // extern nabto_status_t nabtoFree (void *p);
        [DllImport("__Internal")]
        // [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoFree(void* p);

        // extern nabto_status_t nabtoSetApplicationName (const char *applicationName);
        [DllImport("__Internal")]
        //  [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoSetApplicationName(sbyte* applicationName);

        // extern nabto_status_t nabtoSetStaticResourceDir (const char *resourceDir);
        [DllImport("__Internal")]
        //  [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoSetStaticResourceDir(sbyte* resourceDir);

        // extern nabto_status_t nabtoSetOption (const char *name, const char *value);
        [DllImport("__Internal")]
        // [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoSetOption(sbyte* name, sbyte* value);

        // extern nabto_status_t nabtoVersion (int *major, int *minor);
        [DllImport("__Internal")]
        // [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoVersion(int* major, int* minor);

        // extern nabto_status_t nabtoFetchUrl (nabto_handle_t session, const char *nabtoUrl, char **resultBuffer, size_t *resultLen, char **mimeTypeBuffer);
        [DllImport("__Internal")]
        //   [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoFetchUrl(nabto_handle_t* session, sbyte* nabtoUrl, sbyte** resultBuffer, nuint* resultLen, sbyte** mimeTypeBuffer);

        // extern nabto_status_t nabtoSubmitPostData (nabto_handle_t session, const char *nabtoUrl, const char *postBuffer, size_t postLen, const char *postMimeType, char **resultBuffer, size_t *resultLen, char **resultMimeTypeBuffer);
        [DllImport("__Internal")]
        //  [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoSubmitPostData(nabto_handle_t* session, sbyte* nabtoUrl, sbyte* postBuffer, nuint postLen, sbyte* postMimeType, sbyte** resultBuffer, nuint* resultLen, sbyte** resultMimeTypeBuffer);

        // extern nabto_status_t nabtoGetSessionToken (nabto_handle_t session, char *buffer, size_t bufLen, size_t *resultLen);
        [DllImport("__Internal")]
        //  [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoGetSessionToken(nabto_handle_t* session, sbyte* buffer, nuint bufLen, nuint* resultLen);

        ////typedef nabto_async_post_data_status_t(NABTOAPI* NabtoAsyncPostDataCallbackFunc)(char* buf,
        ////                                                                         size_t bufSize,
        ////                                                                          size_t* actualSize,
        ////                                                                          void* userData);
        // This declares the callback signature for the block:



        public delegate nabto_async_post_data_status_t NabtoAsyncPostDataCallbackFunc([MarshalAs(UnmanagedType.LPStr)] string buf, nuint bufSize, nuint actualSize, IntPtr userData);
                                                                      
       // extern nabto_status_t nabtoAsyncSetPostData (nabto_async_resource_t resource, const char *mimeType, NabtoAsyncPostDataCallbackFunc cb, void *userData);
           [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
       public static extern unsafe nabto_status_t nabtoAsyncSetPostData(nabto_async_resource_t* resource, sbyte* mimeType, NabtoAsyncPostDataCallbackFunc cb, void* userData);

        // extern nabto_status_t nabtoAsyncPostData (nabto_async_resource_t resource, const char *data, size_t dataLength);
        [DllImport("__Internal")]
        //  [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoAsyncPostData(nabto_async_resource_t* resource, sbyte* data, nuint dataLength);

        // extern nabto_status_t nabtoAsyncPostClose (nabto_async_resource_t resource);
        [DllImport("__Internal")]
        // [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoAsyncPostClose(nabto_async_resource_t* resource);
     
        // extern nabto_status_t nabtoAsyncFetch (nabto_async_resource_t resource, NabtoAsyncStatusCallbackFunc cb, void *userData);
         //  [DllImport("__Internal")]
        //   [Verify(PlatformInvoke)]
        //  static extern unsafe nabto_status_t nabtoAsyncFetch(nabto_async_resource_t* resource, NabtoAsyncStatusCallbackFunc* cb, void* userData);

        // extern nabto_status_t nabtoGetAsyncData (nabto_async_resource_t resource, char *buf, size_t bufSize, size_t *actualSize);
        [DllImport("__Internal")]
        //  [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoGetAsyncData(nabto_async_resource_t* resource, sbyte* buf, nuint bufSize, nuint* actualSize);

        // extern nabto_status_t nabtoOpenSessionBare (nabto_handle_t *session);
        [DllImport("__Internal")]
        //  [Verify(PlatformInvoke)]
        public  static extern unsafe nabto_status_t nabtoOpenSessionBare(nabto_handle_t** session);

        // extern nabto_status_t nabtoAsyncInit (nabto_handle_t session, nabto_async_resource_t *resource, const char *url);
        [DllImport("__Internal")]
        //   [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoAsyncInit(nabto_handle_t* session, nabto_async_resource_t** resource, sbyte* url);

        // extern nabto_status_t nabtoAsyncClose (nabto_async_resource_t resource);
        [DllImport("__Internal")]
        // [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoAsyncClose(nabto_async_resource_t* resource);

        // extern nabto_status_t nabtoAbortAsync (nabto_async_resource_t resource);
        [DllImport("__Internal")]
        //  [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoAbortAsync(nabto_async_resource_t* resource);

        // extern nabto_status_t nabtoSignup (const char *email, const char *password);
        [DllImport("__Internal")]
        //  [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoSignup(sbyte* email, sbyte* password);

        // extern nabto_status_t nabtoResetAccountPassword (const char *email);
        [DllImport("__Internal")]
        //  [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoResetAccountPassword(sbyte* email);

        // extern nabto_status_t nabtoProbeNetwork (size_t timeoutMillis, const char *host);
        [DllImport("__Internal")]
        // [Verify(PlatformInvoke)]
        public static extern unsafe nabto_status_t nabtoProbeNetwork(nuint timeoutMillis, sbyte* host);

    }
   
  

    [StructLayout(LayoutKind.Sequential)]
    public struct nabto_opaque_handle
    {

    }


    //    /**
    // * This is a struct to an opaque data type - representing a session.
    // * @since 3.0.2
    // */
    //    struct nabto_opaque_handle;

    //    /**
    //     * This is a struct to an opaque data type - representing a stream.
    //     * @since 3.0.2
    //     */
    //    struct nabto_opaque_stream;
    [StructLayout(LayoutKind.Sequential)]
    public struct nabto_opaque_stream
    {

    }
    //    /**
    //     * This is a struct to an opaque data type - representing a tunnel.
    //     * @since 3.0.2
    //     */
    //    struct nabto_opaque_tunnel;
    [StructLayout(LayoutKind.Sequential)]
    public struct nabto_opaque_tunnel
    {
    }

    //    /**
    //     * This is a struct to an opaque data type - representing an asynchronous
    //     * request.
    //     * @since 3.0.2
    //     */
    //    struct nabto_opaque_async_resource;

    [StructLayout(LayoutKind.Sequential)]
    public struct nabto_opaque_async_resource
    {
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct nabto_tunnel_t
    {
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct nabto_stream_t
    {
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct nabto_async_resource_t
    {
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct nabto_handle_t
    {
    }

    //    /**
    //     * This is a handle to an open session.
    //     * @since 3.0.2
    //     */
    //    typedef struct nabto_opaque_handle * nabto_handle_t;

    //[StructLayout(LayoutKind.Sequential)]
    //public struct nabto_opaque_handle *nabto_handle_t
    //{

    //    }
    ///**
    // * This is a handle to an open stream.
    // * @since 3.0.2
    // */
    //typedef struct nabto_opaque_stream * nabto_stream_t;

    ///**
    // * This is a handle to an open tunnel.
    // * @since 3.0.2
    // */
    //typedef struct nabto_opaque_tunnel * nabto_tunnel_t;

    ///**
    // * This is a handle to an asynchronous request.
    // * @since 3.0.2
    // */
    //typedef struct nabto_opaque_async_resource * nabto_async_resource_t;


}

