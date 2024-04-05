using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartynovMTS.ViewModels
{
    public class CallsViewModel
    {
        private string fio;
        private string nameCity;
        private DateTime dateTimeCall;
        private string timeString;
        private string dateString;
        private double durationInMin;
        private double sum;
        private string status;

        public CallsViewModel(Model.Calls obj)
        {
            fio = obj.Clients.Surname + " " + obj.Clients.Name + " " + obj.Clients.Patronumic;
            nameCity = obj.Services.Cities.NameCity;
            dateTimeCall = obj.DateTimeCall;
            durationInMin = obj.DurationCallInSec / 60;
            status = obj.Statuses.NameStatus;
            timeString = dateTimeCall.ToString("HH:mm");
            dateString = dateTimeCall.ToString("yyyy-MM-dd");
            DateTime firstRange = new DateTime(dateTimeCall.Year, dateTimeCall.Month, dateTimeCall.Day, 6, 0, 0, 0, dateTimeCall.Kind);
            DateTime secondRange = new DateTime(dateTimeCall.Year, dateTimeCall.Month, dateTimeCall.Day, 22, 0, 0, 0, dateTimeCall.Kind);
            sum = obj.Services.CostOneMinute * durationInMin;
            if (dateTimeCall >= firstRange && dateTimeCall <= secondRange && obj.Services.PreferentialCost != null) sum = (double)obj.Services.PreferentialCost * durationInMin;
        }

        public string Fio { get => fio; set => fio = value; }
        public string NameCity { get => nameCity; set => nameCity = value; }
        public DateTime DateTimeCall { get => dateTimeCall; set => dateTimeCall = value; }
        public double DurationInMin { get => durationInMin; set => durationInMin = value; }
        public double Sum { get => sum; set => sum = value; }
        public string Status { get => status; set => status = value; }
        public string TimeString { get => timeString; set => timeString = value; }
        public string DateString { get => dateString; set => dateString = value; }
    }
}
