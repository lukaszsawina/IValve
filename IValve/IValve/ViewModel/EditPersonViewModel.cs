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
    public class EditPersonViewModel : Screen
    {
        private readonly IDataAccess _data;
        private readonly IEventAggregator _eventAggregator;
        private readonly IWindowManager _windowManager;

        public IEnumerable<RoleModel> Roles { get; set; }
        public IEnumerable<StatusModel> Statuses { get; set; }
        public IEnumerable<RoomModel> Rooms { get; set; }
        private PersonModel _editedPerson;
        private int _selectedRole;
        private int _selectedStatus;
        private int _selectedRoom;

        public int SelectedRole
        {
            get { return _selectedRole; }
            set
            {
                if (_selectedRole != value)
                {
                    _selectedRole = value;
                    NotifyOfPropertyChange(nameof(SelectedRole));
                }
            }
        }
        public int SelectedStatus
        {
            get { return _selectedStatus; }
            set
            {
                if (_selectedStatus != value)
                {
                    _selectedStatus = value;
                    NotifyOfPropertyChange(nameof(SelectedStatus));
                }
            }
        }
        public int SelectedRoom
        {
            get { return _selectedRoom; }
            set
            {
                if (_selectedRoom != value)
                {
                    _selectedRoom = value;
                    NotifyOfPropertyChange(nameof(SelectedRoom));
                }
            }
        }



        public PersonModel PersonToEdit
        {
            get { return _editedPerson; }
            set 
            {
                if (_editedPerson != value)
                {
                    _editedPerson = value;
                    NotifyOfPropertyChange(nameof(PersonToEdit));
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
        public EditPersonViewModel(IDataAccess data, IEventAggregator eventAggregator, IWindowManager windowManager)
        {
            _data = data;
            _eventAggregator = eventAggregator;
            _windowManager = windowManager;
            Task.Run(() => InitializeData()).Wait();
        }

        private async Task InitializeData()
        {
            string SQL = "SELECT * FROM Roles";
            Roles = await _data.LoadDataSQL<RoleModel>(SQL);
            SQL = "SELECT * FROM Status";
            Statuses = await _data.LoadDataSQL<StatusModel>(SQL);
            SQL = "SELECT * FROM Rooms";
            Rooms = await _data.LoadDataSQL<RoomModel>(SQL);
        }
        public void SetPerson(PersonModel person)
        {
            PersonToEdit = person;
            SelectedRole = Roles.ToList().FindIndex(x=>x.Role_ID == person.Role.Role_ID);
            SelectedStatus = Statuses.ToList().FindIndex(x=>x.Status_ID == person.Status.Status_ID);
            SelectedStatus = Rooms.ToList().FindIndex(x=>x.Room_ID == person.Room.Room_ID);
        }

        public async Task Add()
        {

            //if (Role is null || Status is null || Room is null)
            //    _windowManager.ShowMessageBox("You have to select all options!");
            //else
            //{
            //    var newPerson = new PersonModel() { Firstname = FirstName, Lastname = LastName, BirthDate = Birth, Role = Role.Role_ID ?? 1, Status = Status.Status_ID ?? 1, Room = Room.Room_ID ?? 1 };
            //    var validator = new PersonValidator();
            //    var result = validator.Validate(newPerson);

            //    if (result.IsValid)
            //    {
            //        var parameters = new DynamicParameters();
            //        parameters.Add("FirstName", FirstName);
            //        parameters.Add("LastName", LastName);
            //        parameters.Add("BirthDate", Birth);
            //        parameters.Add("Role", Role.Role_ID);
            //        parameters.Add("Status", Status.Status_ID);
            //        parameters.Add("Room", Room.Room_ID);
            //        parameters.Add("new_id", DbType.Int32, direction: ParameterDirection.Output);

            //        try
            //        {
            //            int newID = await _data.SaveDataSP("sp_NewPerson", parameters);
            //            newPerson.Person_ID = newID;
            //            _eventAggregator.Publish(new NewPersonEvent(newPerson));
            //            Clear();
            //            ErrorMessage = "";

            //        }
            //        catch (Exception ex)
            //        {
            //            ErrorMessage = "Error while saving data";
            //        }
            //    }
            //    else
            //    {

            //        ErrorMessage = result.Errors.Last().ErrorMessage;
            //    }
            //}

        }
        public void Close()
        {
            this.RequestClose();
        }

    }
}
