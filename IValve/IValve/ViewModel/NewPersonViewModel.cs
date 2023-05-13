using Dapper;
using DataAccessLibrary.DbAccess;
using DataAccessLibrary.Models;
using IValve.Events;
using IValve.Validation;
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
        private IEnumerable<RoomModel> _rooms;

        public IEnumerable<RoleModel> Roles { get; set; }
        public IEnumerable<StatusModel> Statuses { get; set; }
        public IEnumerable<RoomModel> Rooms 
        {
            get { return _rooms; }
            set
            {
                if (_rooms != value)
                {
                    _rooms = value;
                    NotifyOfPropertyChange(nameof(Rooms));
                }
            }
        }

        private PersonModel _newPerson = new PersonModel();

        public PersonModel NewPerson
        {
            get { return _newPerson; }
            set 
            {
                if (_newPerson != value)
                {
                    _newPerson = value;
                    NotifyOfPropertyChange(nameof(NewPerson));
                }
            }
        }


        private RoleModel? _role;
        private StatusModel? _status;
        private RoomModel? _room;
        private string _errorMessage = "";

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set 
            {
                if (_errorMessage != value)
                {
                    _errorMessage = value;
                    NotifyOfPropertyChange(nameof(ErrorMessage));
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
            Roles = await _data.LoadDataSQL<RoleModel>(SQL);
            SQL = "SELECT * FROM Status";
            Statuses = await _data.LoadDataSQL<StatusModel>(SQL);
            await RefreshAvaliableRooms();
        }
        public async Task RefreshAvaliableRooms()
        {
            var all_rooms = await _data.LoadRoomsAsync();
            Rooms = all_rooms.Where(x => x.Occupied < x.Capacity).ToList();
        }
        public async Task Add()
        {

            if (NewPerson.Role is null || NewPerson.Status is null || NewPerson.Room is null)
                ErrorMessage = "You have to select all options!";
            else
            {

                var validator = new PersonValidator();
                var result = validator.Validate(NewPerson);

                if (result.IsValid)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("FirstName", NewPerson.Firstname);
                    parameters.Add("LastName", NewPerson.Lastname);
                    parameters.Add("BirthDate", NewPerson.BirthDate);
                    parameters.Add("Role", NewPerson.Role.Role_ID);
                    parameters.Add("Status", NewPerson.Status.Status_ID);
                    parameters.Add("Room", NewPerson.Room.Room_ID);
                    parameters.Add("new_id", DbType.Int32, direction: ParameterDirection.Output);

                    try
                    {
                        int newID = await _data.SaveDataSP("sp_NewPerson", parameters);
                        NewPerson.Person_ID = newID;
                        _eventAggregator.Publish(new NewPersonEvent(NewPerson));
                        Clear();
                        ErrorMessage = "";
                        await RefreshAvaliableRooms();

                    }
                    catch (Exception ex)
                    {
                        ErrorMessage = "Error while saving data";
                    }
                }
                else
                {

                    ErrorMessage = result.Errors.Last().ErrorMessage;
                }
            }
            
        }

        public void Clear()
        {
            if (NewPerson.Firstname is null && NewPerson.Lastname is null && NewPerson.BirthDate == DateTime.MinValue && NewPerson.Role is null && NewPerson.Status is null && NewPerson.Room is null)
                Close();
            NewPerson = new PersonModel();
        }
        public void Close()
        {
            this.RequestClose();
        }

    }
}
