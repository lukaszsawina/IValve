using Dapper;
using DataAccessLibrary.DbAccess;
using IValve.Events;
using IValve.Models;
using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValve.ViewModel
{
    public class NewPersonViewModel : Screen
    {
        private readonly IDataAccess _data;
        private readonly IEventAggregator _eventAggregator;

        public IEnumerable<RoleModel> Roles { get; set; }
        public IEnumerable<StatusModel> Statuses { get; set; }
        public IEnumerable<RoomModel> Rooms { get; set; }

        private string _firstName = "";
        private string _lastName = "";
        private DateTime _birth = DateTime.Now;
        private RoleModel? _role;
        private StatusModel? _status;
        private RoomModel? _room;

        public string FirstName
        {
            get { return _firstName; }
            set 
            { 
                if(_firstName != value)
                {
                    _firstName = value;
                    NotifyOfPropertyChange(nameof(FirstName));
                }
            
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    NotifyOfPropertyChange(nameof(LastName));
                }

            }
        }
        public DateTime Birth
        {
            get { return _birth; }
            set 
            { 
                if(_birth != value)
                {
                    _birth = value;
                    NotifyOfPropertyChange(nameof(Birth));
                }
            }
        }
        public RoleModel? Role
        {
            get { return _role; }
            set
            {
                if (_role != value)
                {
                    _role = value;
                    NotifyOfPropertyChange(nameof(Role));
                }
            }
        }
        public StatusModel? Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    NotifyOfPropertyChange(nameof(Status));
                }
            }
        }
        public RoomModel? Room
        {
            get { return _room; }
            set
            {
                if (_room != value)
                {
                    _room = value;
                    NotifyOfPropertyChange(nameof(Room));
                }
            }
        }

        [Inject]
        public NewPersonViewModel(IDataAccess data, IEventAggregator eventAggregator)
        {
            _data = data;
            _eventAggregator = eventAggregator;
            Task.Run(() => InitializeData()).Wait();
        }

        private async Task InitializeData()
        {
            string SQL = "SELECT * FROM Roles";
            Roles = await  _data.LoadDataSQL<RoleModel>(SQL);
            SQL = "SELECT * FROM Status";
            Statuses = await _data.LoadDataSQL<StatusModel>(SQL);
            SQL = "SELECT * FROM Rooms";
            Rooms = await _data.LoadDataSQL<RoomModel>(SQL);
        }

        public async Task Add()
        {
            var parameters = new DynamicParameters();
            parameters.Add("FirstName", FirstName);
            parameters.Add("LastName", LastName);
            parameters.Add("BirthDate", Birth);
            parameters.Add("Role", Role.Role_ID);
            parameters.Add("Status", Status.Status_ID);
            parameters.Add("Room", Room.Room_ID);
            parameters.Add("new_id", DbType.Int32, direction: ParameterDirection.Output);
            int newID = await _data.SaveDataSP("sp_NewPerson", parameters);
            _eventAggregator.Publish(new NewPersonEvent(new PersonModel() { Person_ID = newID, Firstname = FirstName, Lastname = LastName, BirthDate = Birth, Role = Role.Role_ID, Status = Status.Status_ID, Room = Room.Room_ID}));
            Clear();
        }

        public void Clear()
        {
            if (FirstName == "" && LastName == "" && Birth.Date == DateTime.Now.Date && Role is null && Status is null && Room is null)
                Close();

            FirstName = "";
            LastName = "";
            Birth = DateTime.Now;
            Role = null;
            Status = null;
            Room = null;
        }
        public void Close()
        {
            this.RequestClose();
        }

    }
}
