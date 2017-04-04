using Nabto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Nabto.Views
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

            

        }
        void LoginClicked(object sender, EventArgs e)
        {
      
                var client = DependencyService.Get<INabtoClientService>();
                client.CreatSession(txtEmail.Text, txtPassword.Text);
            this.Navigation.PushAsync(new Main());
        }
    }
}
