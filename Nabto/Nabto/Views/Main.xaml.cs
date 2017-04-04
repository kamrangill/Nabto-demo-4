using Nabto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Nabto.Views
{
    public partial class Main : ContentPage
    {
        public Main()
        {
            InitializeComponent();
           
            }
        
         void  WindowSpeed_IOSClicked(object sender, EventArgs e)
        {
            string XmlData = @"<unabto_queries><query name='wind_speed.json' id='2'><request></request><response format='json'><parameter name='rpc_speed_m_s' type='uint32'/></response></query></unabto_queries>";
            string URL = "nabto://demo.nabto.net/wind_speed.json?";

            var client = DependencyService.Get<INabtoClientService>();
            //await Task.Run(() =>
            //{
            //    txtState.Text = "Wind Speed =" + client.GetRpcInvoke(XmlData, URL);

            //});

            Device.BeginInvokeOnMainThread(() => {
                txtState.Text = "Wind Speed =" + client.GetRpcInvoke(XmlData, URL);
            });
           

        }

      


    }
}
