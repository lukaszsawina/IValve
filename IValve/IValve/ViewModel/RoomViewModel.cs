using DataAccessLibrary.DbAccess;
using DataAccessLibrary.Models;
using IValve.Events;
using Stylet;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace IValve.ViewModel
{
    public class RoomViewModel : Screen, IHandle<EditPersonEvent>, IHandle<NewPersonEvent>
    {
        private readonly IDataAccess _data;
        private readonly IEventAggregator _eventAggregator;

        private BindableCollection<PersonModel> _personInRoom = new BindableCollection<PersonModel>();
        private List<PersonModel> _persons;
        private BindableCollection<RoomModel> _rooms;
        private int _countOfRooms;
        private decimal _percentOfOccupied;
        private int _countOfAvaliable;


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
        public int CountOfRooms
        {
            get { return _countOfRooms; }
            set
            {
                if (_countOfRooms != value)
                {
                    _countOfRooms = value;
                    NotifyOfPropertyChange(nameof(CountOfRooms));
                }
            }
        }
        public decimal PercentOfOccupied
        {
            get { return _percentOfOccupied; }
            set
            {
                if (_percentOfOccupied != value)
                {
                    _percentOfOccupied = value;
                    NotifyOfPropertyChange(nameof(PercentOfOccupied));
                }
            }
        }
        public int CountOfAvaliable
        {
            get { return _countOfAvaliable; }
            set
            {
                if (_countOfAvaliable != value)
                {
                    _countOfAvaliable = value;
                    NotifyOfPropertyChange(nameof(CountOfAvaliable));
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
            Rooms = new BindableCollection<RoomModel>((await _data.LoadRoomsAsync()).OrderBy(x=>x.Room_ID));
            Persons = new List<PersonModel>((await _data.LoadPersonsAsync()).OrderBy(x=>x.Person_ID));
            CalcSatatistic();
        }
        private void CalcSatatistic()
        {
            CountOfRooms = Rooms.Count;
            CountOfAvaliable = Rooms.Where(x => x.Capacity > x.Occupied).Count();
            PercentOfOccupied = (decimal)(CountOfRooms - CountOfAvaliable) / (decimal)CountOfRooms *100;
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
            Task.Run(() => InitialDataAsync()).Wait();
            if (PersonInRoom != null)
                PersonInRoom.Refresh();
        }

        public void Handle(NewPersonEvent e)
        {
            Task.Run(() => InitialDataAsync()).Wait();
            if (PersonInRoom != null)
                PersonInRoom.Refresh();
        }

        public void HandleChecked(object sender, RoutedEventArgs e)
        {
            Rooms = new BindableCollection<RoomModel>(Rooms.Where(x => x.Capacity > x.Occupied));
        }

        public async Task HandleUnchecked(object sender, RoutedEventArgs e)
        {
            Rooms = new BindableCollection<RoomModel>((await _data.LoadRoomsAsync()).OrderBy(x => x.Room_ID));
        }
    }
}
