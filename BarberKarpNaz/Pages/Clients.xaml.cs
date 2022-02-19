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
using BarberKarpNaz.Windows;

namespace BarberKarpNaz.Pages
{
    /// <summary>
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients : Page
    {

        List<EF.Client> ListClient = new List<EF.Client>() { };
        List<string> ListOfSort = new List<string>() { "По умолчанию", "По фамилии", "По имени", "По телефону " };

        public Clients()
        {
            InitializeComponent();
            cmbSort.ItemsSource = ListOfSort;
            cmbSort.SelectedIndex = 0;
            Filter();
        }

        private void Filter()
        {
            ListClient = ClassHelper.AppData.context.Client.ToList().Where(i=>i.IsDeleted==false).ToList();
            ListClient = ListClient.Where(i => i.LastName.Contains(txbSearch.Text) ||
            i.FIrstName.Contains(txbSearch.Text) || i.Phone.Contains(txbSearch.Text)).ToList();
            switch (cmbSort.SelectedIndex)
            {
                case 0:
                    ListClient = ListClient.OrderBy(i => i.Id).ToList();
                    break;
                case 1:
                    ListClient = ListClient.OrderBy(i => i.LastName).ToList();
                    break;
                case 2:
                    ListClient = ListClient.OrderBy(i => i.FIrstName).ToList();
                    break;
                case 3:
                    ListClient = ListClient.OrderBy(i => i.Phone).ToList();
                    break;
                default:
                    break;
            }
            LVClient.ItemsSource = ListClient;
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddClient addClient = new Windows.AddClient();
            Opacity = 0.2;
            addClient.ShowDialog();
            Opacity = 1;
        }

        private void LVClient_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EF.Client client = LVClient.SelectedItem as EF.Client;
            AddClient add = new AddClient(client);
            add.ShowDialog();
        }

        private void LVClient_KeyUp(object sender, KeyEventArgs e)
        {
            EF.Client client= LVClient.SelectedItem as EF.Client;
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                var resClick = MessageBox.Show($"Удалить клиента {/*LVEmployee.SelectedItem as EF.Employee*/ client }", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
                try
                {
                    if (resClick == MessageBoxResult.Yes)
                    {
                        EF.Client userDel = new EF.Client();
                        if (!(LVClient.SelectedItem is EF.Client))
                        {
                            MessageBox.Show("Запись не выбрана");
                            return;
                        }
                        userDel = (LVClient.SelectedItem as EF.Client) ;
                        userDel.IsDeleted = true;
                        ClassHelper.AppData.context.SaveChanges();
                        MessageBox.Show("Клиент удален");
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
    }
}
