﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BarberKarpNaz.Pages;

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
    }
}
