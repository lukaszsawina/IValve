using DataAccessLibrary.DbAccess;
using IValve.Models;
using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IValve.ViewModel
{
    public class Test1ViewModel : Screen
    {
        private readonly IDataAccess _data;
        private IEnumerable<PersonModel> _dataModels;

        public IEnumerable<PersonModel> DataModels
        {
            get { return _dataModels; }
            set 
            {
                if (_dataModels != value)
                {
                    _dataModels = value;
                    NotifyOfPropertyChange(nameof(DataModels));
                }
            }
        }




        
        [Inject]
        public Test1ViewModel(IDataAccess data)
        {
            _data = data;
        }
        public async Task Test()
        {
            string sql_query = "SELECT * FROM person";
            DataModels = await _data.LoadDataSQL<PersonModel>(sql_query);
        }
    }
}
