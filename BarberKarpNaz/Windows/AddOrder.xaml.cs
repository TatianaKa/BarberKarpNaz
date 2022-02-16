using BarberKarpNaz.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        public AddOrder()
        {
            InitializeComponent();
        }
        private void txbPhone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.V)
            {
                e.Handled = true;
            }

            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.Key == Key.C)
            {
                e.Handled = true;
            }
        }

        private void txbPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9 () -]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txbSalary_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txbLastName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^A-Z a-z А-Я а-я ]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txbLastName_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var resClick=MessageBox.Show("Вы уверены?","Вопрос",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (resClick==MessageBoxResult.Yes)
            { 
                var Employ = ClassHelper.AppData.context.Employee.Where(i => i.LastName == txbLastNameEmployee.Text).ToList().FirstOrDefault();
                var Clien = ClassHelper.AppData.context.Client.Where(i => i.LastName == txbLastNameClient.Text).ToList().FirstOrDefault();
                var Serv = ClassHelper.AppData.context.Service.Where(i => i.NameService == txbNameService.Text).ToList().FirstOrDefault();
                DateTime date = DateTime.Now;
                Order order = new Order() {
                    IdEmployee = Employ.Id,
                    IdClient = Clien.Id,
                    IdService = Serv.Id,
                    StartTime = date,
                    EndTime=date.AddMinutes(20)
                };
                ClassHelper.AppData.context.Order.Add(order);
                ClassHelper.AppData.context.SaveChanges();
                MessageBox.Show("Заказ добавлен");
            }
            
           

        }
    }
}
