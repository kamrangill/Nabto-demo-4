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


      
    }
}