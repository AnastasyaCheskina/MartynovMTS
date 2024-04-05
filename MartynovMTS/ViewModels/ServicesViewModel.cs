using MartynovMTS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartynovMTS.ViewModels
{
    public class ServicesViewModel :ViewModelBase
    {
        int idServices;
        DateTime? date;
        int id;
        string costOneMinute;
        string preferentialCost;
        List<Model.Cities> cities = ViewModelBase.databaseConnection.Cities.ToList();

        public ServicesViewModel(Model.Services services)
        {
            idServices = services.IdServices;
            date = services.Date;
            id = services.IdCity;
            costOneMinute = services.CostOneMinute.ToString();
            preferentialCost = services.PreferentialCost.ToString();
        }
        public ServicesViewModel()
        {
            idServices = 0;
            date = DateTime.Now;
            id = 1;
            costOneMinute = string.Empty;
            preferentialCost = string.Empty;
        }

        public int IdServices
        {
            get { return idServices; }
            set
            {
                idServices = value;
                OnPropertyChanged("IdServices");
            }
        }
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("IdCity");
            }
        }
        public string CostOneMinute
        {
            get { return costOneMinute; }
            set
            {
                costOneMinute = value;
                OnPropertyChanged("CostOneMinute");
            }
        }
        public string PreferentialCost
        {
            get { return preferentialCost; }
            set
            {
                preferentialCost = value;
                OnPropertyChanged("PreferentialCost");
            }
        }
        public DateTime? Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        public List<Cities> AllCities { get => cities; set => cities = value; }
    }
}
