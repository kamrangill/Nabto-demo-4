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
using System.Threading;
using System.Threading.Tasks;
using Nabto.Android.Wrapper;
using Nabto.Droid.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(NabtoClientService))]
namespace Nabto.Droid.Services
{

    public class NabtoClientService : INabtoClientService
    {
        public void StartUp()
        {
            var result = Task.Factory.StartNew(() => NabtoManager.StartNabtoClient());


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