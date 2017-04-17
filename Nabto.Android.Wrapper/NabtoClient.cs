using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nabto.Android.Api;
using Android.App;
using Org.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Android.Util;
using System.Text.RegularExpressions;

namespace Nabto.Android.Wrapper

{


    public  class NabtoClient
    {
        private static  NabtoApi instance=null;

       

        private static NabtoApi Instance
        {
            get
            {
                
               return instance;
                 
            }
            set { instance = value;  }
        }
 
        
        private NabtoStatus _Startup;
        private Session _session;
     
        public NabtoStatus Startup
        {
            get
            {
                return _Startup;
            }
        }


        private Session Session
        {
            get
            {
                return _session;
            }

            set
            {
                _session = value;
            }

        }
      
       
        public string Version
        {
            get
            {
                return Instance.Version();
            }
        }

        public void StartUp()
        {

            if (Instance == null)
            {
                Instance = GetInstance();
            }

                _Startup = GetStatus(Instance.Startup());
            
          
           
        }
        private static NabtoApi GetInstance()
        {
            var AssestManager = new NabtoAndroidAssetManager(Application.Context);
           return new NabtoApi(AssestManager);
        }
        public NabtoStatus Shutdown()
        {
            if (Startup != NabtoStatus.Ok)
            {
                throw new Exception(Startup.ToString());
            }
            return GetStatus(Instance.Shutdown());
        }


        public NabtoStatus OpenSession(string Email,string Password)
        {
            if (Startup !=NabtoStatus.Ok)
            {
                throw new Exception(Startup.ToString());
            }

            _session = Instance.OpenSession(Email, Password);
         
            return GetStatus(_session.Status);
        }

        public NabtoStatus CloseSession()
        {
            if (Session ==null)
            {
                throw new Exception(Session.Status.Name());
            }
          return GetStatus(instance.CloseSession(Session));

        }

        public NabtoStatus RpcSetDefaultInterface(string InterfaceDefinition, ref byte ErrorMessage)
        {
            if (Startup != NabtoStatus.Ok)
            {
                throw new Exception(Startup.ToString());
            }

            if (GetStatus(Session.Status) != NabtoStatus.Ok)
            {
                throw new Exception(Session.Status.Name());
            }
            var result = Instance.RpcSetDefaultInterface(InterfaceDefinition, this.Session);

            if (GetStatus(result.Status)!=NabtoStatus.Ok)
            {
                ErrorMessage = (byte)result.Status.Ordinal();
            }

            return GetStatus(result.Status);
            
        }
        public NabtoStatus RpcInvoke(string URL, ref  string Json)
        {
            if (Startup != NabtoStatus.Ok)
            {
                throw new Exception(Startup.ToString());
            }

            if (GetStatus(Session.Status) != NabtoStatus.Ok)
            {
                throw new Exception(Session.Status.Name());
            }
            var result = Instance.RpcInvoke(URL, this.Session);
            if (GetStatus(result.Status)==NabtoStatus.Ok)
            {
                string Data = Regex.Replace(result.Json, @"\r\n?|\n", "");
                //  JSONObject reader = new JSONObject(Data);
                /// JSONObject resp = reader.GetJSONObject("response");
                //  Json = (byte)Convert.ToInt32(resp.GetString("rpc_speed_m_s"));

                Json = Data;
            }
           

            return GetStatus(result.Status);
        }

        private NabtoStatus GetStatus(Nabto.Android.Api.NabtoStatus status)
        {
            switch (status.Name())
            {
                case "OK":
                return NabtoStatus.Ok;
                case "Aborted":
                return NabtoStatus.Aborted;
                case "AddressInUse":
                    return NabtoStatus.AddressInUse;
                case "ApiNotInitialized":
                    return NabtoStatus.ApiNotInitialized;
                case "BufferFull":
                    return NabtoStatus.BufferFull;
                case "CertSavingFailure":
                    return NabtoStatus.CertSavingFailure;
                case "CertSigningError":
                    return NabtoStatus.CertSigningError;
                case "ConnectToHostFailed":
                    return NabtoStatus.ConnectToHostFailed;
                case "DataPending":
                    return NabtoStatus.DataPending;
                case "ErrorCodeCount":
                    return NabtoStatus.ErrorCodeCount;

                case "ErrorReadingConfig":
                    return NabtoStatus.ErrorReadingConfig;

                case "Failed":
                    return NabtoStatus.Failed;


                case "FailedWithJsonMessage":
                    return NabtoStatus.FailedWithJsonMessage;

                case "IllegalParameter":
                    return NabtoStatus.IllegalParameter;
              
                case "InvalidAddress":
                    return NabtoStatus.InvalidAddress;
                case "InvalidResource":
                    return NabtoStatus.InvalidResource;
                case "InvalidSession":
                    return NabtoStatus.InvalidSession;

                case "InvalidStream":
                    return NabtoStatus.InvalidStream;
                case "InvalidStreamOption":
                    return NabtoStatus.InvalidStreamOption;

                case "InvalidStreamOptionArgument":
                    return NabtoStatus.InvalidStreamOptionArgument;

                case "InvalidTunnel":
                    return NabtoStatus.InvalidTunnel;

                case "NoNetwork":
                    return NabtoStatus.NoNetwork;

                case "NoProfile":
                    return NabtoStatus.NoProfile;


                case "OpenCertOrPkFailed":
                    return NabtoStatus.OpenCertOrPkFailed;


                case "PortalLoginFailure":
                    return NabtoStatus.PortalLoginFailure;


                case "StreamClosed":
                    return NabtoStatus.StreamClosed;
                case "StreamingUnsupported":
                    return NabtoStatus.StreamingUnsupported;
                case "UnlockPkFailed":
                    return NabtoStatus.UnlockPkFailed;
                default:
                    return NabtoStatus.Aborted;
            }

        }

    }
}
