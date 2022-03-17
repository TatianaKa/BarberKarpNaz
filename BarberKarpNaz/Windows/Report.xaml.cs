using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace BarberKarpNaz.Windows
{
    /// <summary>
    /// Логика взаимодействия для Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        //List<double> Salary = new List<double> { };
        public Report()
        {
            InitializeComponent();
            LvReport.ItemsSource = ClassHelper.AppData.context.Employee.ToList();
        }

        private void btnSalary_Click(object sender, RoutedEventArgs e)
        {

            EF.Employee employee = LvReport.SelectedItem as EF.Employee;
            //var Lists =new List<double>{ };
            //Lists =ClassHelper.AppData.context.Order.Where(i => i.IdEmployee == employee.Id).Select(j => ((double)j.FinishCost)).ToList() ;
            //txbSalary.Text=( ClassHelper.CountSalary.Salary(Lists)).ToString();
            DateTime from =Convert.ToDateTime( txbFromDate.Text);
            DateTime to =Convert.ToDateTime( txbToDate.Text);
            var Lists =new List<double>{ };
            Lists =ClassHelper.AppData.context.Order.Where(i => i.IdEmployee == employee.Id&& (i.StartTime>=from && i.StartTime <= to)).Select(j => (double)j.FinishCost) .ToList();
            txbSalary.Text=( ClassHelper.CountSalary.Salary(Lists)).ToString();

        }

    }
}
