using BarberKarpNaz.EF;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace BarberKarpNaz.Windows
{
    public partial class AddEmployee : Window
    {
        public AddEmployee()
        {
            InitializeComponent();
            cmbGender.ItemsSource = ClassHelper.AppData.context.Gender.ToList();
            cmbGender.DisplayMemberPath = "Name";
            cmbGender.SelectedIndex = 0;

            cmbSpec.ItemsSource=ClassHelper.AppData.context.Speciality.ToList();
            cmbSpec.DisplayMemberPath = "NameSpeciality";
            cmbSpec.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txbFirstName.Text==null)
            {
                MessageBox.Show("Заполните поле Имя");
            }
            if (txbLastName.Text==null)
            {
                MessageBox.Show("Заполните поле Фамилия");
            }
            if (txbPhone.Text==null)
            {
                MessageBox.Show("Заполните поле Телефон");
            }
            if (txbSalary.Text==null)
            {
                MessageBox.Show("Заполните поле Зарплата");
            }
            if (txbLogin.Text==null)
            {
                MessageBox.Show("Запоните поле Логин");
            }
            if (txbPassword.Text==null)
            {
                MessageBox.Show("Заполните поле Пароль");
            }


           var resClick= MessageBox.Show("Вы уверены","Вопрос",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (resClick== MessageBoxResult.Yes)
            {
                Employee employee = new Employee()
                {
                    LastName = txbLastName.Text,
                    FirstName = txbFirstName.Text,
                    Patronymic = txbPatronymic.Text,
                    Phone = txbPhone.Text,
                    Salary = Convert.ToInt32(txbSalary.Text),
                    Login = txbLogin.Text,
                    GenderCode = cmbGender.SelectedIndex + 1,
                    IdSpeciality = cmbGender.SelectedIndex + 1,
                };
                if (txbPassword.Text==txbResPassword.Text)
                {
                    employee.Password = txbPassword.Text;
                }
                ClassHelper.AppData.context.Employee.Add(employee);
                ClassHelper.AppData.context.SaveChanges();
            }
            MessageBox.Show("Пользователь успешно добавлен!");
            this.Close();
        }


        private void txbPhone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Space)
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

        private void txbPhone_PreviewTextInput(object sender,TextCompositionEventArgs e)
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
            Regex regex = new Regex("[^A-Z a-z А-Я а-я]+");
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
    }
}
