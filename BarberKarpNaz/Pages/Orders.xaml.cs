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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BarberKarpNaz.Pages
{
    /// <summary>
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : Page
    {
        List<EF.Order> ListOrder = new List<EF.Order>() { };
        public Orders()
        {
            InitializeComponent();
            Filter();
        }
        private void Filter()
        {
            ListOrder = ClassHelper.AppData.context.Order.ToList();
            LVOrder.ItemsSource = ListOrder;
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddOrder add = new Windows.AddOrder();
            Opacity = 0.2;
            add.ShowDialog();
            Opacity = 1;
        }


        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
