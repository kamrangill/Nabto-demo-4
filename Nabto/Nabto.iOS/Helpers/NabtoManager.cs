using Nabto.IOS.Wrapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Nabto.iOS.Services
{
    public static class NabtoManager
    {
        public static NabtoClient Client;
        public static nabto_tunnel_t TunnelInstance;
        public static nabto_status_t isApiInitialized;
        public static nabto_status_t SessionStatus;
        public static string Email;
        public static string Password;
        public static void StartNabtoClient()
        {
             Client = new NabtoClient();
            isApiInitialized= Client.Startup();

            TestAPI_RPInvoke();

        }
        public static nabto_status_t OpenSession(string Email,string Password)
        {
         //   Client = (NabtoClient)(NabtoClient.Instance);
         
            //Save Credentails for locally
            NabtoManager.Email = Email;
            NabtoManager.Password = Password;
            
            //Check if Api is Not Initialized

            if (isApiInitialized !=nabto_status_t.Ok)
            {
                Client = new NabtoClient();
                isApiInitialized = Client.Startup();
            }

            //Open Session

            SessionStatus =  Client.OpenSession(Email, Password);
           
           Debug.WriteLine("Session Status=" + SessionStatus);

            return SessionStatus;
        }

        public static nabto_status_t OpenTCPTunnel(string Host, int Port)
        {
            Client = (NabtoClient)(NabtoClient.Instance);

            var Status = Client.TunnelOpenTcp(ref TunnelInstance, Host, Port);
        

            return Status;
        }

        public static string CloseTunnel()
        {
            Client = (NabtoClient)(NabtoClient.Instance);
            return Client.TunnelClose(ref TunnelInstance).ToString();
        }
        public static string GetTunnelState()
        {
        
               if (Client != null)
            {
               
                var Status = Client.TunnelInfo(TunnelInstance);
          
                Debug.WriteLine("Tunnel Info=" + Status.ToString());
                return Status.ToString();

            }
            else
            {
                var info = "CLOSED";
                return info;
            }
        }



        public static string CallQuery(string URL, string query_XMLData)
        {
            byte errorMessage = 0;
             Client = (NabtoClient)(NabtoClient.Instance);

            // Debug.WriteLine("Credentails" + Email+" "+ Password);

            if (isApiInitialized!=nabto_status_t.Ok)
            {
                Client = new NabtoClient();

            }
            if (Client.GetSessionToken==string.Empty)
            {
                Client.OpenSession(Email, Password);
            }
          
            var status = Client.RpcSetDefaultInterface(query_XMLData, ref errorMessage);
            byte json = 0;
            Debug.WriteLine("call Xml Interface Status=" + status);


            status= Client.RpcInvoke(URL, ref json);

            Debug.WriteLine("call Xml RPCInvoke Status=" + status);

            Debug.WriteLine("rpcInvoke finished with result % = " + json);
           // Client.CloseSession();
          //  Client.Shutdown();
            return json.ToString();
        }

        public static void TestAPI_RPInvoke()
        {
          //  NabtoClient api = new NabtoClient();

            

            Debug.WriteLine("Client Status=" + isApiInitialized);

            var status = Client.OpenSessionGuest();
            Debug.WriteLine("Session Status=" + status);
          
            string XmlData = @"<unabto_queries><query name='wind_speed.json' id='2'><request></request><response format='json'><parameter name='rpc_speed_m_s' type='uint32'/></response></query></unabto_queries>";
            string URL = "nabto://demo.nabto.net/wind_speed.json?";
            CallQuery(URL, XmlData);
        }
       


       
    }
}
