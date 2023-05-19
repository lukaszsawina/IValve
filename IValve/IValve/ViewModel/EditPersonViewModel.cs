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

        public IEnumerable<RoleModel> Roles { get; set; }
        public IEnumerable<StatusModel> Statuses { get; set; }
        private IEnumerable<RoomModel> _rooms;

        private PersonModel _editedPerson;
        private int _selectedRole;
        private int _selectedStatus;
        private int _selectedRoom;

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
        public EditPersonViewModel(IDataAccess data, IEventAggregator eventAggregator)
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
        private async Task RefreshAvaliableRooms()
        {
            var all_rooms = await _data.LoadRoomsAsync();
            if(PersonToEdit != null)
                Rooms = all_rooms.Where(x => x.Occupied < x.Capacity || x.Room_ID == PersonToEdit.Room.Room_ID).ToList();
        }
        public async Task SetPerson(PersonModel person)
        {
            PersonToEdit = new PersonModel()
            {
                Person_ID = person.Person_ID,
                Firstname = person.Firstname,
                Lastname = person.Lastname,
                BirthDate = person.BirthDate,
                Role = person.Role,
                Status = person.Status,
                Room = person.Room
            };
            await RefreshAvaliableRooms();

            SelectedRole = Roles.ToList().FindIndex(x=>x.Role_ID == person.Role.Role_ID);
            SelectedStatus = Statuses.ToList().FindIndex(x=>x.Status_ID == person.Status.Status_ID);
            SelectedRoom = Rooms.ToList().FindIndex(x=>x.Room_ID == person.Room.Room_ID);
        }

        public async Task Save()
        {
            if (PersonToEdit.Role is null || PersonToEdit.Status is null || PersonToEdit.Room is null)
                ErrorMessage = "You have to select all options!";
            else
            {

                var validator = new PersonValidator();
                var result = validator.Validate(PersonToEdit);

                if (result.IsValid)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("FirstName", PersonToEdit.Firstname);
                    parameters.Add("LastName", PersonToEdit.Lastname);
                    parameters.Add("BirthDate", PersonToEdit.BirthDate);
                    parameters.Add("Role", PersonToEdit.Role.Role_ID);
                    parameters.Add("Status", PersonToEdit.Status.Status_ID);
                    parameters.Add("Room", PersonToEdit.Room.Room_ID);
                    parameters.Add("ID", PersonToEdit.Person_ID);

                    try
                    {
                        await _data.UpdateDataSP("sp_EditPerson", parameters);
                        _eventAggregator.Publish(new EditPersonEvent(PersonToEdit));
                        Close();

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
        public void Close()
        {
            this.RequestClose();
        }

    }
}
