using MartynovMTS.ViewModels;
using MartynovMTS.Views;
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

namespace MartynovMTS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mainFrame.Navigate(new StartPage());
            ViewModelBase.MainFrame = mainFrame;
        }

        private void btnServises_Click(object sender, RoutedEventArgs e)
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

        private void btnClients_Click(object sender, RoutedEventArgs e)
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

        private void btnCalls_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModelBase.MainFrame.Navigate(new Calls());
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
