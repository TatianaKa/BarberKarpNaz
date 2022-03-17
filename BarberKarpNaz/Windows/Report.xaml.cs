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

namespace BarberKarpNaz.Windows
{
    /// <summary>
    /// Логика взаимодействия для Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        List<double> Salary = new List<double> { };
        public Report()
        {
            InitializeComponent();
            LvReport.ItemsSource = ClassHelper.AppData.context.Employee.ToList();
        }

        private void btnSalary_Click(object sender, RoutedEventArgs e)
        {
          
            EF.Employee employee = LvReport.SelectedItem as EF.Employee;
            var Sum = ClassHelper.AppData.context.Order.ToList().Where(i => i.IdEmployee == employee.Id).Select(i => i.FinishCost).ToList();
            //ClassHelper.AppData.context.Order.Where(i => i.IdEmployee == employee.Id).Select(i => i.FinishCost).ToList();
           ClassHelper.CountSalary.Salary();

        }
    }
}
