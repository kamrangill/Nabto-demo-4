using Nabto.Models;
using Nabto.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Nabto
{
    public class App : Application
    {
        public App()
        {
          
            Login lg = new Login();
           var nav = new NavigationPage(lg);
            MainPage = nav;
        }

        protected override void OnStart()
        {
            
                var client = DependencyService.Get<INabtoClientService>();
                client.StartUp();

     
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {

   
            // Handle when your app resumes
        }
    }
}
