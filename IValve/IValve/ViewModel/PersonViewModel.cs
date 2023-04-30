using DataAccessLibrary.DbAccess;
using IValve.Models;
using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IValve.ViewModel
{
    public class PersonViewModel : Screen
    {
        private readonly IDataAccess? _data;
        private IEnumerable<PersonModel> _personsList;
        private FullPersonModel _selected;

        public FullPersonModel SelectedPerson
        {
            get { return _selected; }
            set 
            {
                if (_selected != value)
                {
                    _selected = value;
                    NotifyOfPropertyChange(nameof(SelectedPerson));
                }
            }
        }


        public IEnumerable<PersonModel> PersonsList
        {
            get { return _personsList; }
            set
            {
                if (_personsList != value)
                {
                    _personsList = value;
                    NotifyOfPropertyChange(nameof(PersonsList));
                }
            }
        }

        [Inject]
        public PersonViewModel(IDataAccess data)
        {
            _data = data;
            Task.Run(() => this.LoadPersonsAsync()).Wait();
        }
        public async Task LoadPersonsAsync()
        {
            string sql_query = "SELECT * FROM person";
            PersonsList = await _data.LoadDataSQL<PersonModel>(sql_query);
        }

        public void ChangeSelectedPerson(object sender, SelectedCellsChangedEventArgs  e) 
        {
            var selected = (PersonModel)e.AddedCells[0].Item;
            var values = new { ID = selected.Person_ID};
            Task.Run(() => SelectedPerson = _data.LoadDataSP<FullPersonModel, dynamic>("sp_GetFullPerson", values).Result.First());
        }
    }
}
