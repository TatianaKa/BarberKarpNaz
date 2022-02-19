using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BarberKarpNaz.Pages
{
    /// <summary>
    /// Логика взаимодействия для Services.xaml
    /// </summary>
    public partial class Services : Page
    {
        public Services()
        {
            InitializeComponent();
            LVService.ItemsSource = ClassHelper.AppData.context.Service.ToList().Where(i => i.IsDeleted == false);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddService addservice = new Windows.AddService();
            Opacity = 0.2;
            addservice.ShowDialog();
            Opacity = 1;
        }

        private void LVEmployee_KeyUp(object sender, KeyEventArgs e)
        {
            EF.Service service = LVService.SelectedItem as EF.Service;
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                var resClick = MessageBox.Show($"Удалить услугу {/*LVEmployee.SelectedItem as EF.Employee*/ service }", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);

                try
                {
                    if (resClick == MessageBoxResult.Yes)
                    {
                        EF.Service userDel = new EF.Service();
                        if (!(LVService.SelectedItem is EF.Service))
                        {
                            MessageBox.Show("Запись не выбрана");
                            return;
                        }
                        userDel = (LVService.SelectedItem as EF.Service);
                        userDel.IsDeleted = true;
                        ClassHelper.AppData.context.SaveChanges();
                        MessageBox.Show("Услуга удалена");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }

            }

        }

    }
}
