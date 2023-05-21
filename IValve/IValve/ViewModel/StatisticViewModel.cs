using DataAccessLibrary.DbAccess;
using DataAccessLibrary.Models;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValve.ViewModel
{
    public class StatisticViewModel: Screen
    {
        private readonly IDataAccess _data;

        public List<PersonModel> Persons { get; set; } = new List<PersonModel>();
        private StatisticModel _statistic = new StatisticModel();

        public StatisticModel Statistic
        {
            get { return _statistic; }
            set
            {
                if (_statistic != value)
                {
                    _statistic = value;
                    NotifyOfPropertyChange(nameof(Statistic));
                }
            }
        }


        public StatisticViewModel(IDataAccess data)
        {
            _data = data;
            Task.Run(() => { InitializeData(); }).Wait();
        }
        private async Task InitializeData()
        {
            Persons = (await _data.LoadPersonsAsync()).ToList();
        }
        public void CalcStat()
        {
            try 
            {
                Statistic = new StatisticModel()
                {
                    TotalDrink = Statistic.TotalDrink,
                    TotalFood = Statistic.TotalFood,
                    WaterDayLeft = (int) (Statistic.TotalDrink / (1.5M * Persons.Count))
                };
            }
            catch(Exception ex)
            {
            }

        }

        public void Close()
        {
            this.RequestClose();
        }

    }
}
