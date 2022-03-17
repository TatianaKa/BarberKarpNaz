using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BarberKarpNaz.Windows;

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
            ListEmployee = ClassHelper.AppData.context.Employee.ToList().Where(i => i.IsDeleted == false).ToList();
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
            LVEmployee.Items.Refresh();
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


        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void LVEmployee_KeyUp(object sender, KeyEventArgs e)
        {
            EF.Employee employee = LVEmployee.SelectedItem as EF.Employee;
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                var resClick = MessageBox.Show($"Удалить сотрудника {employee.LastName }", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                try
                {
                    if (resClick == MessageBoxResult.Yes)
                    {
                        EF.Employee userDel = new EF.Employee();
                        if (!(LVEmployee.SelectedItem is EF.Employee))
                        {
                            MessageBox.Show("Запись не выбрана");
                            return;
                        }
                        userDel = (LVEmployee.SelectedItem as EF.Employee);
                        userDel.IsDeleted = true;
                        ClassHelper.AppData.context.SaveChanges();
                        MessageBox.Show("Сотрудник удален");
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }

            }
            Filter();

        }

        private void LVEmployee_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EF.Employee employee = LVEmployee.SelectedItem as EF.Employee;
            AddEmployee add = new AddEmployee(employee);
            add.ShowDialog();
        }

    }
}
