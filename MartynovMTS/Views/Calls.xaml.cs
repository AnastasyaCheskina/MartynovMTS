using MartynovMTS.ViewModels;
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

namespace MartynovMTS.Views
{
    /// <summary>
    /// Логика взаимодействия для Calls.xaml
    /// </summary>
    public partial class Calls : Page
    {
        public Calls()
        {
            InitializeComponent();
            List<CallsViewModel> listCalls = new List<CallsViewModel>();
            List<Model.Calls> databaseCalls = ViewModelBase.databaseConnection.Calls.ToList();
            foreach (var call in databaseCalls)
            {
                listCalls.Add(new CallsViewModel(call));
            }
            tableCalls.ItemsSource = listCalls;
        }
    }
}
