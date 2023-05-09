using DataAccessLibrary.DbAccess;
using DataAccessLibrary.Models;
using IValve.Events;
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
        private readonly EditPersonViewModel _editPersonView;
        private BindableCollection<PersonModel> _personsList;
        private PersonModel _selected;

        public PersonModel SelectedPerson
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
        public PersonViewModel(IDataAccess data, IWindowManager window, IEventAggregator eventAggregator, NewPersonViewModel newPersonView, EditPersonViewModel editPersonView)
        {
            _data = data;
            _window = window;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            _newPersonView = newPersonView;
            _editPersonView = editPersonView;
            Task.Run(() => this.LoadPersonsAsync()).Wait();
        }
        public async Task LoadPersonsAsync()
        {
            var result = await _data.LoadPersonsAsync();
            PersonsList = new BindableCollection<PersonModel>(result);
        }

        public void ChangeSelectedPerson(object sender, SelectedCellsChangedEventArgs  e) 
        {
            SelectedPerson = (PersonModel)e.AddedCells[0].Item;
        }

        public void ShowNewPersonWindow()
        {
            _window.ShowWindow(_newPersonView);
        }

        public void ShowEditPersonWindow()
        {
            if(SelectedPerson != null)
            {
                _window.ShowWindow(_editPersonView);
                _editPersonView.SetPerson( PersonsList.Where(x => x.Person_ID == SelectedPerson.Person_ID).First());
            }
        }

        public void Handle(NewPersonEvent message)
        {
            PersonsList.Add(message.NewPerson);
        }
    }
}
