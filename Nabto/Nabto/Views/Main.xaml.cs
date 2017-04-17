using Nabto.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        
         void  WindowSpeed_Clicked(object sender, EventArgs e)
        {
            string XmlData = @"<unabto_queries><query name='wind_speed.json' id='2'><request></request><response format='json'><parameter name='rpc_speed_m_s' type='uint32'/></response></query></unabto_queries>";
            string URL = "nabto://demo.nabto.net/wind_speed.json?";

            var client = DependencyService.Get<INabtoClientService>();
           

            Device.BeginInvokeOnMainThread(() => {

                string JsonData= client.GetRpcInvoke(XmlData, URL);
                if (JsonData!=string.Empty)
                {
                    txtwindSpeed.Text = "Wind Speed =" + GetWindSpeedFromJson(JsonData) + " m/s";

                }

            });
           


        }

        private int GetWindSpeedFromJson(string JsonData)
        {
            int WindSpeed = 0;
          
           

            dynamic Jsonobjects = JObject.Parse(JsonData);
            var response = (JObject)Jsonobjects["response"];
              var windspeed = (string)response["rpc_speed_m_s"];

            WindSpeed= Convert.ToInt32(windspeed.ToString());


            return WindSpeed;


        }
      


    }
}
