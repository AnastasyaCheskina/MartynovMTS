using MartynovMTS.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace MartynovMTS.Views
{
    /// <summary>
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients : Page
    {
        List<Model.Clients> allClients = ViewModelBase.databaseConnection.Clients.ToList();
        public Clients()
        {
            InitializeComponent();
            tableClients.ItemsSource = allClients;
        }

        private void btnChangeInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                int idClient = Convert.ToInt32(button.Tag);
                var client = allClients.FirstOrDefault(x=>x.IdClient == idClient);
                if (client != null)
                {
                    ViewModelBase.MainFrame.Navigate(new EditOrAddClient(client));
                }
                else
                {
                    MessageBox.Show("Выбранный клиент не найден в базе данных :(", "Упс, что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Trace.WriteLine(ex.Message);
                MessageBox.Show("Произошла непредвиденная ошибка\nСообщение об ошибке: " + ex.Message, "Упс, что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void addNewClientBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModelBase.MainFrame.Navigate(new EditOrAddClient());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Trace.WriteLine(ex.Message);
                MessageBox.Show("Произошла непредвиденная ошибка\nСообщение об ошибке: " + ex.Message, "Упс, что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
