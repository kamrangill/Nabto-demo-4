using Nabto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Nabto.Views
{
    public partial class Tunneling : ContentPage
    {
     
      //  static bool CheckState=true;
        public Tunneling()
        {
            InitializeComponent();
            txtState.Text = "Tunnel State:";

        }
         void TunnelingClicked(object sender, EventArgs e)
        {
            
                if (Device.OS == TargetPlatform.Android)
                {
                // iOS-specific code
               
                    AndroidTunnelCall();

              
                }

            if (Device.OS == TargetPlatform.iOS)
            {
               
                    IOSTunnelCall();
               

                }
            


            }
          void GetTunnelStatusClicked(object sender, EventArgs e)
        {
            if (Device.OS == TargetPlatform.Android)
            {
              

                    // The code that runs in a background thread.
                    var client = DependencyService.Get<INabtoClientService>();
                    var API = Application.Current.Properties["API"];
                    var Tunnel = Application.Current.Properties["Tunnel"];

                    txtState.Text = "Tunnel State: " + client.GetTunnelState(API, Tunnel);

              
            }
            if (Device.OS == TargetPlatform.iOS)
            {
             
                    // The code that runs in a background thread.
                    var client = DependencyService.Get<INabtoClientServiceIOS>();

                    txtState.Text = "Tunnel State: " + client.GetTunnelState();

              
            }


        }
        async void TunnelShutdownClicked(object sender, EventArgs e)
        {
            if (Device.OS == TargetPlatform.Android)
            {
                await Task.Run(() =>
                {


                    var client = DependencyService.Get<INabtoClientService>();
                    var API = Application.Current.Properties["API"];
                    var Tunnel = Application.Current.Properties["Tunnel"];
                    client.ShutDownTunnel(API, Tunnel);
                    txtState.Text = "Tunnel State: " + client.GetTunnelState(API, Tunnel);

                });
            }


            if (Device.OS == TargetPlatform.iOS)
            {
                await Task.Run(() =>
                {

                    var client = DependencyService.Get<INabtoClientServiceIOS>();
                    client.ShutDownTunnel();
                    txtState.Text = "Tunnel State: " + client.GetTunnelState();
                });
            }
        }

        private async void AndroidTunnelCall()
        {
            var client = DependencyService.Get<INabtoClientService>();
            var API = Application.Current.Properties["API"];
            var Tunnel = client.CreatTunnel(8080, "streamdemo.nabto.net", "127.0.0.1", 80, API, Application.Current.Properties["Session"]);
            if (Application.Current.Properties.Keys.Contains("Tunnel") == false)
            {
                Application.Current.Properties.Add("Tunnel", Tunnel);
            }
            else
            {
                Application.Current.Properties.Remove("Tunnel");
                Application.Current.Properties.Add("Tunnel", Tunnel);
            }
            var Status = string.Empty;

            bool StopCheckingStatus = false;
         
            while (StopCheckingStatus == false)
            {
                Status = client.GetTunnelState(API, Tunnel);
                txtState.Text = "Tunnel State: " + Status;
                await Task.Delay(1000);

                switch (Status.Trim().ToUpper())
                {
                    case "REMOTE_RELAY_MICRO":
                        StopCheckingStatus = false;
                        break;
                    case "CLOSED":
                        StopCheckingStatus = true;
                        break;
                    case "REMOTE_RELAY":
                        StopCheckingStatus = false;
                        break;
                }

            }



        }

        private async void IOSTunnelCall()
        {
            var client = DependencyService.Get<INabtoClientServiceIOS>();
           
            var Status = client.OpenTCPTunnel("streamdemo.nabto.net",80);

            await Task.Delay(1000);


            // bool StopCheckingStatus = false;
              Status = client.GetTunnelState();
               txtState.Text = "Tunnel Status: " + Status;





        }

    }
}
