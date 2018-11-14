using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UitslagControle.Services;
using Windows.UI.Xaml.Controls;

namespace UitslagControle.Views
{
    public sealed partial class InvoerDossierPage : Page, INotifyPropertyChanged
    {
        public InvoerDossierPage()
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

        private async void InvoerButton_ClickAsync(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ProgressDossier.IsActive = true;

            Network net = new Network();
            String data = await net.GetFileDataKewillAsync(DossierTextBox.Text);

            //throw new NotImplementedException(); //Display all data in OrderPanel

            Frame.Navigate(typeof(OrderOpenPage));

            ProgressDossier.IsActive = false;
        }

        private void Option1RadioButton_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void Option2RadioButton_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void Option3RadioButton_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void Option4RadioButton_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void Option5RadioButton_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void Option6RadioButton_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void Option7RadioButton_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        private void DossierTextBox_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                InvoerButton_ClickAsync(sender, e);
            }
        }

        private void InvoerButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }
    }
}
