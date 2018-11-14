using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UitslagControle2.Services;
using System.Threading.Tasks;
using System.Configuration;

namespace UitslagControle2.Views
{
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private void InlogButton_Click(object sender, RoutedEventArgs e)
        {
            if (Webservice.AuthLDAP(UsernameTextbox.Text, PasswordBox.Password))
            {
                Console.WriteLine("Auth werkt");
            }
        }

        //private async Task<bool> Login(string username, string password)
        //{
        //    return true;
        //}

    }
}
