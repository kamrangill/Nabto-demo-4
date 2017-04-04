using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Nabto.Android.Wrapper
{
    public enum NabtoStatus : uint
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
}