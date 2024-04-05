using MartynovMTS.Model;
using MartynovMTS.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MartynovMTS.ViewModels
{
    public class ViewModelBase: INotifyPropertyChanged
    {
        public static MTSEntities databaseConnection = new MTSEntities();
        public static Frame MainFrame = new Frame();
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
