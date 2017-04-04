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
using Nabto.Android.Wrapper;


namespace Nabto.Droid.Helpers
{
    public static class NabtoManager
    {
        public static NabtoClient Client;
     
        public static string Email;
        public static string Password;
        public static void StartNabtoClient()
        {
            Client = new NabtoClient();
            Client.StartUp();

         
        }
        public static NabtoStatus OpenSession(string Email, string Password)
        {
           
            NabtoManager.Email = Email;
            NabtoManager.Password = Password;
            var Status = Client.OpenSession(Email, Password);
            return Status;
        }

        public static string CallQuery(string URL, string query_XMLData)
        {
            byte errorMessage = 0;
           
            var status = Client.RpcSetDefaultInterface(query_XMLData, ref errorMessage);
            byte json = 0;

            status = Client.RpcInvoke(URL, ref json);

            return json.ToString();
        }

        public static void TestAPI_RPInvoke()
        {
        
            var status = Client.OpenSession("guest","123456");
        
            string XmlData = @"<unabto_queries><query name='wind_speed.json' id='2'><request></request><response format='json'><parameter name='rpc_speed_m_s' type='uint32'/></response></query></unabto_queries>";
            string URL = "nabto://demo.nabto.net/wind_speed.json?";
            CallQuery(URL, XmlData);
        }
     
       

    }
}