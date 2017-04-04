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
            isApiInitialized= Client.Startup;

       
        }
        public static nabto_status_t OpenSession(string Email,string Password)
        {
            //Save Credentails for locally
            NabtoManager.Email = Email;
            NabtoManager.Password = Password;
            
           
            //Open Session

            SessionStatus =  Client.OpenSession(Email, Password);
           
         //  Debug.WriteLine("Session Status=" + SessionStatus);

            return SessionStatus;
        }

        public static string CallQuery(string URL, string query_XMLData)
        {

           
            byte errorMessage = 0;
            var status = Client.RpcSetDefaultInterface(query_XMLData, ref errorMessage);
            byte json = 0;
             status = Client.RpcInvoke(URL, ref json);
          
            return json.ToString();
        }


        public static nabto_status_t OpenTCPTunnel(string Host, int Port)
        {
            var Status = Client.TunnelOpenTcp(ref TunnelInstance, Host, Port);
        

            return Status;
        }

        public static string CloseTunnel()
        {
           
            return Client.TunnelClose(ref TunnelInstance).ToString();
        }
        public static string GetTunnelState()
        {
        
                var Status = Client.TunnelInfo(TunnelInstance);
              //  Debug.WriteLine("Tunnel Info=" + Status.ToString());
                return Status.ToString();
           
        }



      
        public static void TestAPI_RPInvoke()
        {

            Email = "guest";
            Password = "12346";

            Debug.WriteLine("Client Status=" + isApiInitialized);

            var status = Client.OpenSession(Email, Password);

            Debug.WriteLine("Session Token=" + Client.GetSessionToken);

         
            Debug.WriteLine("Session Status=" + status);
          
            string XmlData = @"<unabto_queries><query name='wind_speed.json' id='2'><request></request><response format='json'><parameter name='rpc_speed_m_s' type='uint32'/></response></query></unabto_queries>";
            string URL = "nabto://demo.nabto.net/wind_speed.json?";
            CallQuery(URL, XmlData);
        }
       


       
    }
}
