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
    /// Логика взаимодействия для Servises.xaml
    /// </summary>
    public partial class Servises : Page
    {
        List<Model.Services> allServices = ViewModelBase.databaseConnection.Services.ToList();
        public Servises()
        {
            InitializeComponent();
            tableServices.ItemsSource = allServices;
        }

        private void btnChangeInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                int idService = Convert.ToInt32(button.Tag);
                var service = allServices.FirstOrDefault(x => x.IdServices == idService);
                if (service != null)
                {
                    ViewModelBase.MainFrame.Navigate(new EditOrAddService(service));
                }
                else
                {
                    MessageBox.Show("Выбранный тариф не найден в базе данных :(", "Упс, что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Trace.WriteLine(ex.Message);
                MessageBox.Show("Произошла непредвиденная ошибка\nСообщение об ошибке: " + ex.Message, "Упс, что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void addNewServiceBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModelBase.MainFrame.Navigate(new EditOrAddService());
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
