using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nabto.iOS.Services;
using Nabto.Models;
using System.Threading.Tasks;
using Nabto.IOS.Wrapper;
using System.Diagnostics;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(NabtoClientService))]
namespace Nabto.iOS.Services
{
    class NabtoClientService : INabtoClientService
    {
        public void StartUp()
        {
            Task.Factory.StartNew(() => NabtoManager.StartNabtoClient());
           // Task.Factory.StartNew(() => NabtoManager.TestAPI_RPInvoke());

        }
        public string CreatSession(string UserName, string Password)
        {
            var Status = Task.Factory.StartNew(() => NabtoManager.OpenSession(UserName, Password));

            return Status.Result.ToString();
        }

        public string GetRpcInvoke(string XMLData, string URL)
        {
           
                var Status = Task.Factory.StartNew(() => NabtoManager.CallQuery(URL, XMLData));
            
            return Status.Result.ToString();
        }

        public string GetTunnelState()
        {
          var State=  Task.Factory.StartNew(() => NabtoManager.GetTunnelState());

            return State.Result.ToString();
        }

        public string OpenTCPTunnel(string remoteHost, int remotePort)
        {
          var Status=  Task.Factory.StartNew(() => NabtoManager.OpenTCPTunnel(remoteHost, remotePort));
            //   Debug.WriteLine("Tunnel result=" + Status.Result.ToString());
            string LocalStatus = string.Empty;
            if (Status.Result==nabto_status_t.Ok)
            {
                LocalStatus = "OK";
            }

            Debug.WriteLine("Tunnel Status=" + LocalStatus);

            return LocalStatus.ToString();
        }

        public string ShutDownTunnel()
        {
            var Status = Task.Factory.StartNew(() => NabtoManager.CloseTunnel());
            return Status.Result.ToString();

        }

      
    }
}