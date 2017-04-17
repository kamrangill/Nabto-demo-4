using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
//using Nabto.IOS.Wrapper;
namespace Nabto.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            /* NabtoClient client = new NabtoClient();
               if (client.NabtoStartup==nabto_status_t.Ok)
               {

                   if (client.NabtoOpenSession("Guest", "123456")==nabto_status_t.Ok)
                   {
                       //client.NabtoFetchUrl("")

                   }
               }
               //   var Status=  client.NabtoStartup();
               //   CFunctions CF;
               */
        
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
