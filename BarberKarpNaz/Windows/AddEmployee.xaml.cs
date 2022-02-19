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
        bool isEdit=true;
        EF.Employee employeeEdit = new Employee();
        public AddEmployee()
        {
            isEdit = false;
            InitializeComponent();
            cmbGender.ItemsSource = ClassHelper.AppData.context.Gender.ToList();
            cmbGender.DisplayMemberPath = "Name";
            cmbGender.SelectedIndex = 0;

            cmbSpec.ItemsSource=ClassHelper.AppData.context.Speciality.ToList();
            cmbSpec.DisplayMemberPath = "NameSpeciality";
            cmbSpec.SelectedIndex = 0;

        } 
        
        public AddEmployee(EF.Employee employee)
        {
            InitializeComponent();
            cmbGender.ItemsSource = ClassHelper.AppData.context.Gender.ToList();
            cmbGender.DisplayMemberPath = "Name";
            cmbGender.SelectedIndex = Convert.ToInt32(employee.GenderCode -1);

            cmbSpec.ItemsSource=ClassHelper.AppData.context.Speciality.ToList();
            cmbSpec.DisplayMemberPath = "NameSpeciality";
            cmbSpec.SelectedIndex = Convert.ToInt32(employee.IdSpeciality- 1);

            tbTitle.Text = "Изменение сотрудника";
            btnAdd.Content = "Изменить";
            txbLastName.Text = employee.LastName;
            txbFirstName.Text = employee.FirstName;
            txbPatronymic.Text = employee.Patronymic;
            txbPhone.Text = employee.Phone;
            txbSalary.Text = employee.Salary.ToString();
            txbLogin.Text = employee.Login;
            txbPassword.Text = employee.Password;
            employeeEdit = employee;
            ClassHelper.AppData.context.SaveChanges();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txbLastName.Text))
            {
                MessageBox.Show("Заполните поле Фамилия");
                return;
            }

            if (string.IsNullOrWhiteSpace(txbFirstName.Text))
            {
                MessageBox.Show("Заполните поле Имя");
                return;
            }
            
            if (string.IsNullOrWhiteSpace(txbPhone.Text))
            {
                MessageBox.Show("Заполните поле Телефон");
                return;
            }
            if (string.IsNullOrWhiteSpace(txbSalary.Text))
            {
                MessageBox.Show("Заполните поле Зарплата");
                return;
            }
            if (string.IsNullOrWhiteSpace(txbLogin.Text))
            {
                MessageBox.Show("Запоните поле Логин");
                return;
            }
            if (string.IsNullOrWhiteSpace(txbPassword.Text))
            {
                MessageBox.Show("Заполните поле Пароль");
                return;
            }
            var userPhone = ClassHelper.AppData.context.Employee.Where(i => i.Phone == txbPhone.Text).ToList().FirstOrDefault();
            var userLogin = ClassHelper.AppData.context.Employee.Where(i => i.Login == txbLogin.Text).ToList().FirstOrDefault();
            
            if (userPhone!=null)
            {
                MessageBox.Show("Данный номер телефона уже есть в системе ","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            
            if (userLogin!=null)
            {
                MessageBox.Show("Данный логин уже есть в системе ","Ошибка",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }

            var resClick= MessageBox.Show("Вы уверены","Вопрос",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (resClick== MessageBoxResult.Yes)
            {
                //Изменение
                if (isEdit)
                {
                    employeeEdit.LastName = txbLastName.Text;
                    employeeEdit.FirstName = txbFirstName.Text;
                    employeeEdit.Patronymic = txbPatronymic.Text;
                    employeeEdit.Phone = txbPhone.Text;
                    employeeEdit.Salary = Convert.ToInt32(txbSalary.Text);
                    employeeEdit.Login = txbLogin.Text;
                    employeeEdit.GenderCode = cmbGender.SelectedIndex + 1;
                    employeeEdit.IdSpeciality = cmbGender.SelectedIndex + 1;
                    ClassHelper.AppData.context.SaveChanges();
                    MessageBox.Show("Пользователь успешно изменен!");
                    this.Close();
                }
                else
                //Добавление
                {
                    Employee employee = new Employee();
                    employee.LastName = txbLastName.Text;
                    employee.FirstName = txbFirstName.Text;
                    employee.Patronymic = txbPatronymic.Text;
                    employee.Phone = txbPhone.Text;
                    employee.Salary = Convert.ToInt32(txbSalary.Text);
                    employee.Login = txbLogin.Text;
                    employee.GenderCode = cmbGender.SelectedIndex + 1;
                    employee.IdSpeciality = cmbGender.SelectedIndex + 1;
                    if (txbPassword.Text==txbResPassword.Text)
                    {
                    employee.Password = txbPassword.Text;
                    }
                    ClassHelper.AppData.context.Employee.Add(employee);
                    ClassHelper.AppData.context.SaveChanges();
                    MessageBox.Show("Пользователь успешно добавлен!");
                    this.Close();
                };
            }
           
        }

        //Проверка
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
