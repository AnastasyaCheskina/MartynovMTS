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
    /// Логика взаимодействия для EditOrAddClient.xaml
    /// </summary>
    public partial class EditOrAddClient : Page
    {
        Model.Clients client;
        public EditOrAddClient()
        {
            InitializeComponent();
            client = new Model.Clients();
            DataContext = client;
            btnDelete.IsEnabled = false;
        }
        public EditOrAddClient(Model.Clients client)
        {
            InitializeComponent();
            this.client = client;
            DataContext = this.client;
            btnDelete.IsEnabled = true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (client.PhoneNumber != null && client.PhoneNumber != string.Empty && client.PhoneNumber != "" &&
                client.Surname != null && client.Surname != string.Empty && client.Surname != "" &&
                client.Name != null && client.Name != string.Empty && client.Name != "")
            {
                if (client.IdClient == 0)
                {
                    try
                    {
                        ViewModelBase.databaseConnection.Clients.Add(client);
                        ViewModelBase.databaseConnection.SaveChanges();
                        MessageBox.Show("Клиент успешно сохранен!");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        Trace.WriteLine(ex.Message);
                        MessageBox.Show("Произошла непредвиденная ошибка\nСообщение об ошибке: " + ex.Message, "Упс, что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    try
                    {
                        ViewModelBase.databaseConnection.SaveChanges();
                        MessageBox.Show("Клиент успешно изменен!");
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        Trace.WriteLine(ex.Message);
                        MessageBox.Show("Произошла непредвиденная ошибка\nСообщение об ошибке: " + ex.Message, "Упс, что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else MessageBox.Show("Заполнены не все поля", "Упс, что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModelBase.MainFrame.Navigate(new Clients());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Trace.WriteLine(ex.Message);
                MessageBox.Show("Произошла непредвиденная ошибка\nСообщение об ошибке: " + ex.Message, "Упс, что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                int id = Convert.ToInt32(button.Tag);
                var obj = ViewModelBase.databaseConnection.Clients.FirstOrDefault(c => c.IdClient == id);
                if (obj != null)
                {
                    ViewModelBase.databaseConnection.Clients.Remove(obj);
                    ViewModelBase.databaseConnection.SaveChanges();
                    MessageBox.Show("Клиент успешно удален!");
                    ViewModelBase.MainFrame.Navigate(new Clients());
                }
                else MessageBox.Show("Клиент не найден в базе данных", "Упс, что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Error);
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
