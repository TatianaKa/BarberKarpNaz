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
        List<EF.Employee> ListOrder = new List<EF.Employee>() { };
        List<string> ListOfSort = new List<string>() { "По умолчанию", "По фамилии", "По имени", "По специальности" };
        public Orders()
        {
            InitializeComponent();
            cmbSort.ItemsSource = ListOfSort;
            cmbSort.SelectedIndex = 0;
            Filter();
        }
        private void Filter()
        {
            ListOrder = ClassHelper.AppData.context.Employee.ToList();
            ListOrder = ListOrder.Where(i => i.LastName.Contains(txbSearch.Text) ||
            i.FirstName.Contains(txbSearch.Text) || i.Phone.Contains(txbSearch.Text)).ToList();
            switch (cmbSort.SelectedIndex)
            {
                case 0:
                    ListOrder = ListOrder.OrderBy(i => i.Id).ToList();
                    break;
                case 1:
                    ListOrder = ListOrder.OrderBy(i => i.LastName).ToList();
                    break;
                case 2:
                    ListOrder = ListOrder.OrderBy(i => i.FirstName).ToList();
                    break;
                case 3:
                    ListOrder = ListOrder.OrderBy(i => i.IdSpeciality).ToList();
                    break;
                default:
                    break;
            }
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
