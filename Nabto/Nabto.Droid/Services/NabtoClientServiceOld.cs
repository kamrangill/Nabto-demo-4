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
using Nabto;
using Nabto.Droid.Services;
using Nabto.Models;
using Nabto.Android.Api;
using System.Threading;
using System.Threading.Tasks;
using Nabto.Android.Wrapper;
[assembly: Xamarin.Forms.Dependency(typeof(NabtoClientServiceold))]
namespace Nabto.Droid.Services
{
    public  class NabtoClientServiceold : INabtoClientService
    {
       

       
        public object CreatSession(string UserName, string Password,object API)
        {

          //Android.Wrapper.NabtoClient api;
          
            
            var obj_API = (NabtoApi)(API);
            Session session =    obj_API.OpenSession(UserName, Password);
            return session;
        }
        public string FatchURL(object API, object Session,string URL)
        {
            string Data=string.Empty;
            var obj_API = (NabtoApi)(API);

           var Result= obj_API.FetchUrl(URL, (Session)(Session));
            Data= System.Text.Encoding.UTF8.GetString(Result.GetResult());
            return Data;
        }


        public object Startup()
        {
            try
            {
               
                    var AssestManager = new NabtoAndroidAssetManager(Application.Context);
                 var    objApi = new NabtoApi(AssestManager);
                    NabtoStatus st = objApi.Startup();


                return objApi;

            }
            catch (Exception ex)
            {
                return ex;
            }

        }

        public object CreatTunnel(int Localport, string nabtoHost, string remoteHost, int remotePort,object API,object Session)
        {
          //  string State = string.Empty;
            var api = (NabtoApi)(API);

          var Tunnel=  api.TunnelOpenTcp(Localport, nabtoHost, remoteHost, remotePort, (Session)(Session));
            if (Tunnel.Status == NabtoStatus.Ok)
            {
                var Tinfo = api.TunnelInfo((Tunnel)(Tunnel));
               var State = Tinfo.TunnelState.Name();
               


            }
           
            return Tunnel;
        }

        public string GetTunnelState(object API,object Tunnel)
        {
            string State = string.Empty;
            var api = (NabtoApi)(API);
          
            var LocalTunnel = ((Tunnel)(Tunnel));
           
            if (LocalTunnel.Status == NabtoStatus.Ok)
            {
                var Tinfo = api.TunnelInfo(LocalTunnel);
                State = Tinfo.TunnelState.Name();
                
            }
            return State;
       
        }



        public void ShutDownTunnel(object API, object Tunnel)
        {
            var api = (NabtoApi)(API);
            var TunnelLocal = (Tunnel)(Tunnel);
            api.TunnelClose(TunnelLocal);

            //TunnelLocal.Dispose();
          

        }
    }
}