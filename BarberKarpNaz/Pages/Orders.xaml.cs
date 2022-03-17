using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            LVOrder.Items.Refresh();
            ListOrder = ClassHelper.AppData.context.Order.ToList();
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
