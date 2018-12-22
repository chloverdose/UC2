using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UitslagControle.Services;
using Windows.UI.Xaml.Controls;

namespace UitslagControle.Views
{
    public sealed partial class OrderOpenPage : Page, INotifyPropertyChanged
    {
        public OrderOpenPage()
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

        private void AantalPlus_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Misc misc = new Misc();
            misc.PlusOne(AantalBox);
        }

        private void AantalMin_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Misc misc = new Misc();
            misc.MinOne(AantalBox);
        }

        private void VerwachtCheckbox_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            //VerwachtPanel.Background = 
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VervoerderCombobox.SelectedValue.Equals("ON-HOLD"))
            {
                RedenPanel.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                RedenPanel.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        private async void DossierafrondenButton_ClickAsync(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            
        }

        private async void DossierverwijderenButton1_ClickAsync(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Network net = new Network();
            string response = await net.PostDeleteFileDataAsync(DossiernummerLabel.Text);

            this.Frame.Navigate(typeof(InvoerDossierPage));
        }
    }
}
