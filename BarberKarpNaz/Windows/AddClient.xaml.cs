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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        EF.Client clientEdit =new Client();
        private bool isEdit=true;
        public AddClient()
        {
            InitializeComponent();
            isEdit = false;
        }
        public AddClient(EF.Client client)
        {
            InitializeComponent();
            tbTitle.Text = "Изменение клиента";
            btnAdd.Content = "Изменение";
            txbLastName.Text = client.LastName;
            txbFirstName.Text = client.FIrstName;
            txbPatronymic.Text = client.Patronymic;
            txbEmail.Text = client.Email;
            txbPhone.Text = client.Phone;
            clientEdit = client;
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
            if (string.IsNullOrWhiteSpace(txbEmail.Text))
            {
                MessageBox.Show("Заполните поле Email");
                return;
            }

            if (string.IsNullOrWhiteSpace(txbPhone.Text))
            {
                MessageBox.Show("Заполните поле Телефон");
                return;
            }


            var resClick = MessageBox.Show("Вы уверены", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resClick == MessageBoxResult.Yes)
            {
                if (isEdit)
                {

                    clientEdit.LastName =txbLastName.Text;
                    clientEdit.FIrstName=txbFirstName.Text;
                    clientEdit.Patronymic=txbPatronymic.Text;
                    clientEdit.Email=txbEmail.Text;
                    clientEdit.Phone=txbPhone.Text;
                    ClassHelper.AppData.context.SaveChanges();
                    MessageBox.Show("Пользователь успешно изменен!");
                    this.Close();
                }
                else
                {
                    Client client = new Client();
                    client.LastName = txbLastName.Text;
                    client.FIrstName = txbFirstName.Text;
                    client.Patronymic = txbPatronymic.Text;
                    client.Phone = txbPhone.Text;
                    client.Email = txbEmail.Text;
                    ClassHelper.AppData.context.Client.Add(client);
                    ClassHelper.AppData.context.SaveChanges();
                    MessageBox.Show("Пользователь успешно добавлен!");
                    this.Close();
                };
               
            }
           
        }


        private void txbPhone_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Space)
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

        private void txbPhone_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9 () -]+");
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
