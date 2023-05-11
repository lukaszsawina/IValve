using DataAccessLibrary.DbAccess;
using DataAccessLibrary.Models;
using IValve.Events;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IValve.ViewModel
{
    public class RoomViewModel : Screen, IHandle<EditPersonEvent>
    {
        private readonly IDataAccess _data;
        private readonly IEventAggregator _eventAggregator;
        private BindableCollection<RoomModel> _rooms;
        private List<PersonModel> _persons;
        private BindableCollection<PersonModel> _personInRoom = new BindableCollection<PersonModel>();

        public BindableCollection<PersonModel> PersonInRoom
        {
            get { return _personInRoom; }
            set 
            {
                if(_personInRoom != value)
                {
                    _personInRoom = value;
                    NotifyOfPropertyChange(nameof(PersonInRoom));
                }
            }
        }

        public List<PersonModel> Persons
        {
            get { return _persons; }
            set
            {
                if (_persons != value)
                {
                    _persons = value;
                    NotifyOfPropertyChange(nameof(Persons));
                }
            }
        }


        public BindableCollection<RoomModel> Rooms
        {
            get { return _rooms; }
            set 
            { 
                if(_rooms != value)
                {
                    _rooms = value;
                    NotifyOfPropertyChange(nameof(Rooms));
                }        
            }
        }

        public RoomViewModel(IDataAccess data, IEventAggregator eventAggregator)
        {
            _data = data;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            Task.Run(() => this.InitialDataAsync()).Wait();
        }

        private async Task InitialDataAsync()
        {
            Rooms = new BindableCollection<RoomModel>(await _data.LoadRoomsAsync());
            Persons = new List<PersonModel>(await _data.LoadPersonsAsync());

        }

        public void ChangeSelectedPerson(object sender, SelectedCellsChangedEventArgs e)
        {
            if(PersonInRoom != null && e.AddedCells.Count != 0)
            {
                var room = (RoomModel)e.AddedCells[0].Item;
                PersonInRoom = new BindableCollection<PersonModel>(Persons.Where(x => x.Room.Room_ID == room.Room_ID)); 
            }
        }

        public void Handle(EditPersonEvent e)
        {
            var obj = Persons.First(x=> x.Person_ID == e.NewPerson.Person_ID);
            obj = e.NewPerson;
            if(PersonInRoom != null)
                PersonInRoom.Refresh();
            Task.Run(()=> InitialDataAsync()).Wait();
        }
    }
}
