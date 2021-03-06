﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UitslagControle.Services;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace UitslagControle.Views
{
    public sealed partial class LoginPage : Page, INotifyPropertyChanged
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private async void InlogButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ProgressLogin.IsActive = true;

            if (!String.IsNullOrWhiteSpace(UsernameTextbox.Text) && !String.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                try
                {
                    Auth auth = new Auth();
                    if (await auth.LdapAsync(UsernameTextbox.Text, PasswordBox.Password))
                    {
                        Network getdata = new Network();
                        string returndata = await getdata.GetProfileValuesAsync(UsernameTextbox.Text);
                        //Logging startlogging = new Logging();
                        //await startlogging.StartSessionAsync();

                        //Navigeer naar volgende pagina
                        this.Frame.Navigate(typeof(InvoerDossierPage));
                    }
                }
                catch
                {
                    var dialog = new MessageDialog("NOPE");
                    await dialog.ShowAsync();
                }
                
            }
            else
            {
                ToolTip tip = new ToolTip
                {
                    Content = "Gebruikersnaam en wachtwoord mogen niet leeg zijn."
                };
                ToolTipService.SetToolTip(InlogButton, tip);
            }

            ProgressLogin.IsActive = false;
        }

        private void PasswordBox_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                InlogButton_Click(sender, e);
            }
        }
    }
}
