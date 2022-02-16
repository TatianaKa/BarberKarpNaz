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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BarberKarpNaz.Pages;
using BarberKarpNaz.Windows;

namespace BarberKarpNaz
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }


        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            var userAuth = ClassHelper.AppData.context.Employee.Where(i => i.Login == txbLogin.Text && i.Password == txbPassword.Password).ToList().FirstOrDefault();
            if (userAuth != null)
            {
                MenuWindow menu = new MenuWindow();
                txbLogin.Clear();
                txbPassword.Clear();
                this.Hide();
                menu.ShowDialog();
                this.Show();
            }
        }
    }
}