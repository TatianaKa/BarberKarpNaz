using System;
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

        private void BtnCatalog_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new CatalogPage());
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new AddPage());
        }

        private void BtnStaff_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new StaffPage());
        }

        private void BtnMaterial_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new MaterialPage());
        }

        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new ReportPage());
        }
    }
}
