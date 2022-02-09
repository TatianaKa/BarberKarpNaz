using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BarberKarpNaz.Pages
{
    /// <summary>
    /// Логика взаимодействия для Employees.xaml
    /// </summary>
    public partial class Employees : Page
    {
        List<EF.Employee> ListEmployee = new List<EF.Employee>() { };
        List<string> ListOfSort = new List<string>() { "По умолчанию", "По фамилии", "По имени", "По специальности" };
        public Employees()
        {
            InitializeComponent();
            cmbSort.ItemsSource = ListOfSort;
            cmbSort.SelectedIndex = 0;
            Filter();
        }
        private void Filter()
        {
            ListEmployee = ClassHelper.AppData.context.Employee.ToList();
            ListEmployee = ListEmployee.Where(i => i.LastName.Contains(txbSearch.Text) ||
            i.FirstName.Contains(txbSearch.Text) || i.Phone.Contains(txbSearch.Text)).ToList();
            switch (cmbSort.SelectedIndex)
            {
                case 0:
                    ListEmployee = ListEmployee.OrderBy(i => i.Id).ToList();
                    break;
                case 1:
                    ListEmployee = ListEmployee.OrderBy(i => i.LastName).ToList();
                    break;
                case 2:
                    ListEmployee = ListEmployee.OrderBy(i => i.FirstName).ToList();
                    break;
                case 3:
                    ListEmployee = ListEmployee.OrderBy(i => i.IdSpeciality).ToList();
                    break;
                default:
                    break;
            }
            LVEmployee.ItemsSource = ListEmployee;
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddEmployee addEmployee = new Windows.AddEmployee();
            Opacity = 0.2;
            addEmployee.ShowDialog();
            Opacity = 1;
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
