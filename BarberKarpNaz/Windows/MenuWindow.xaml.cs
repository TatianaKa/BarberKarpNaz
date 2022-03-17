using BarberKarpNaz.Pages;
using System;
using System.Collections.Generic;
using System.Windows;

namespace BarberKarpNaz.Windows
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Employees());
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Clients());
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Orders());
        }

        private void btnService_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Services());
        }
        private void myFrame_ContentRendered(object sender, EventArgs e)
        {
            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            Report report = new Report();
            report.ShowDialog();
        }
    }
}
