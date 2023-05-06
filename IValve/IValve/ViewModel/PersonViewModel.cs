using DataAccessLibrary.DbAccess;
using IValve.Events;
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
    public class PersonViewModel : Screen, IHandle<NewPersonEvent>
    {
        private readonly IDataAccess? _data;
        private readonly IWindowManager _window;
        private readonly IEventAggregator _eventAggregator;
        private readonly NewPersonViewModel _newPersonView;
        private BindableCollection<PersonModel> _personsList;
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


        public BindableCollection<PersonModel> PersonsList
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
        public PersonViewModel(IDataAccess data, IWindowManager window, IEventAggregator eventAggregator, NewPersonViewModel newPersonView)
        {
            _data = data;
            _window = window;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            _newPersonView = newPersonView;
            Task.Run(() => this.LoadPersonsAsync()).Wait();
        }
        public async Task LoadPersonsAsync()
        {
            string sql_query = "SELECT * FROM person";
            var result = await _data.LoadDataSQL<PersonModel>(sql_query);
            PersonsList = new BindableCollection<PersonModel>(result);

        }

        public void ChangeSelectedPerson(object sender, SelectedCellsChangedEventArgs  e) 
        {
            var selected = (PersonModel)e.AddedCells[0].Item;
            var values = new { ID = selected.Person_ID};
            Task.Run(() => SelectedPerson = _data.LoadDataSP<FullPersonModel, dynamic>("sp_GetFullPerson", values).Result.First());
        }

        public void ShowAWindow()
        {
            _window.ShowWindow(_newPersonView);
        }

        public void Handle(NewPersonEvent message)
        {
            PersonsList.Add(message.NewPerson);
        }
    }
}
