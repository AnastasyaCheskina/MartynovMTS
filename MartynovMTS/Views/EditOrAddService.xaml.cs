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
    /// Логика взаимодействия для EditOrAddService.xaml
    /// </summary>
    public partial class EditOrAddService : Page
    {
        ServicesViewModel ServicesViewModel;
        Model.Services services;
        public EditOrAddService()
        {
            InitializeComponent();
            ServicesViewModel = new ServicesViewModel();
            DataContext = ServicesViewModel;
            services = new Model.Services();
            btnDelete.IsEnabled = false;
        }
        public EditOrAddService(Model.Services services)
        {
            InitializeComponent();
            ServicesViewModel = new ServicesViewModel(services);
            DataContext = ServicesViewModel;
            this.services = services;
            btnDelete.IsEnabled = true;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                int id = Convert.ToInt32(button.Tag);
                var obj = ViewModelBase.databaseConnection.Services.FirstOrDefault(c => c.IdServices == id);
                if (obj != null)
                {
                    ViewModelBase.databaseConnection.Services.Remove(obj);
                    ViewModelBase.databaseConnection.SaveChanges();
                    MessageBox.Show("Тариф успешно удален!");
                    ViewModelBase.MainFrame.Navigate(new Servises());
                }
                else MessageBox.Show("Тариф не найден в базе данных", "Упс, что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Trace.WriteLine(ex.Message);
                MessageBox.Show("Произошла непредвиденная ошибка\nСообщение об ошибке: " + ex.Message, "Упс, что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModelBase.MainFrame.Navigate(new Servises());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Trace.WriteLine(ex.Message);
                MessageBox.Show("Произошла непредвиденная ошибка\nСообщение об ошибке: " + ex.Message, "Упс, что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ServicesViewModel.CostOneMinute != null && ServicesViewModel.CostOneMinute != string.Empty && ServicesViewModel.CostOneMinute != "" &&
                ServicesViewModel.PreferentialCost != null && ServicesViewModel.PreferentialCost != string.Empty && ServicesViewModel.PreferentialCost != "")
            {
                if (ServicesViewModel.IdServices == 0)
                {
                    try
                    {
                        services.IdServices = ServicesViewModel.IdServices;
                        services.Date = ServicesViewModel.Date;
                        services.IdCity = ServicesViewModel.Id;
                        services.CostOneMinute = Convert.ToDouble(ServicesViewModel.CostOneMinute);
                        services.PreferentialCost = Convert.ToDouble(ServicesViewModel.PreferentialCost);
                        ViewModelBase.databaseConnection.Services.Add(services);
                        ViewModelBase.databaseConnection.SaveChanges();
                        MessageBox.Show("Тариф успешно сохранен!"); 
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
                        services = ViewModelBase.databaseConnection.Services.FirstOrDefault(x => x.IdServices == ServicesViewModel.IdServices);
                        if (services != null)
                        {
                            services.Date = ServicesViewModel.Date;
                            services.IdCity = ServicesViewModel.Id;
                            services.CostOneMinute = Convert.ToDouble(ServicesViewModel.CostOneMinute);
                            services.PreferentialCost = Convert.ToDouble(ServicesViewModel.PreferentialCost);
                            ViewModelBase.databaseConnection.SaveChanges();
                            MessageBox.Show("Тариф успешно изменен!");
                        }
                        else MessageBox.Show("Тариф не найден в базе данных и не может быть изменен", "Упс, что-то пошло не так!", MessageBoxButton.OK, MessageBoxImage.Error);
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
    }
}
