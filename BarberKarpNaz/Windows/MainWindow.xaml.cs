using BarberKarpNaz.Windows;
using System.Linq;
using System.Windows;

namespace BarberKarpNaz
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }


        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            var userAuth = ClassHelper.AppData.context.Employee.Where(i => i.Login == txbLogin.Text && i.Password == txbPassword.Password).ToList().FirstOrDefault();
            if (userAuth != null)
            {
                MenuWindow menu = new MenuWindow();
                txbLogin.Clear();
                txbPassword.Clear();
                this.Hide();
                menu.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Проверьте правильность введенных данных");
            }
        }
    }
}
