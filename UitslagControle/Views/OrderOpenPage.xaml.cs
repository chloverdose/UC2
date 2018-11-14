﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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

        }

        private void AantalMin_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }
    }
}