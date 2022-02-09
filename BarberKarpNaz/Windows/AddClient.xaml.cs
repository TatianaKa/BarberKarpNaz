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
        public AddClient()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txbFirstName.Text == null)
            {
                MessageBox.Show("Заполните поле Имя");
            }
            if (txbLastName.Text == null)
            {
                MessageBox.Show("Заполните поле Фамилия");
            }
            if (txbPhone.Text == null)
            {
                MessageBox.Show("Заполните поле Телефон");
            }


            var resClick = MessageBox.Show("Вы уверены", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resClick == MessageBoxResult.Yes)
            {
                Client client= new Client()
                {
                    LastName = txbLastName.Text,
                    FIrstName = txbFirstName.Text,
                    Patronymic = txbPatronymic.Text,
                    Phone = txbPhone.Text,
                    Email=txbEmail.Text
                };
                ClassHelper.AppData.context.Client.Add(client);
                ClassHelper.AppData.context.SaveChanges();
            }
            MessageBox.Show("Пользователь успешно добавлен!");
            this.Close();
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
