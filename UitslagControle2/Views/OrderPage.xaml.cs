using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Windows.UI.Xaml.Controls;

namespace UitslagControle2.Views
{
    public sealed partial class OrderPage : Page, INotifyPropertyChanged
    {
        public OrderPage()
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

        private void Calc(TextBox box, string operation)
        {
            if (String.IsNullOrWhiteSpace(box.Text))
            {
                box.Text = "0";
            }

            int temp = int.Parse(box.Text);

            switch (operation)
            {
                case "+":
                    temp += 1;
                    break;
                case "-":
                    temp -= 1;
                    break;
                default:
                    temp = 0;
                    break;
            }

            if (temp < 0)
                temp = 0;

            box.Text = temp.ToString();
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void AantalPlus_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Calc(AantalBox, "+");
        }

        private void AantalMin_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Calc(AantalBox, "-");
        }
    }
}
