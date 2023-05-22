using Dapper;
using DataAccessLibrary.DbAccess;
using DataAccessLibrary.Models;
using IValve.Events;
using IValve.Validation;
using Stylet;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IValve.ViewModel
{
    public class NewJobViewModel : Screen
    {
        private readonly IDataAccess _data;
        private readonly IEventAggregator _eventAggregator;
        private JobModel _newjob = new JobModel();
        private BindableCollection<PersonModel> _avaliablePersons = new BindableCollection<PersonModel>();
        private BindableCollection<PersonModel> _selectedPersons = new BindableCollection<PersonModel>();
        private PersonModel _selectedPerson = new PersonModel();
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
        public PersonModel SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                if (_selectedPerson != value)
                {
                    _selectedPerson = value;
                    NotifyOfPropertyChange(nameof(SelectedPerson));
                }
            }
        }

        public List<JobTypeModel> JobType { get; set; } = new List<JobTypeModel>();

        public BindableCollection<PersonModel> AvaliablePersons
        {
            get { return _avaliablePersons; }
            set
            {
                if (_avaliablePersons != value)
                {
                    _avaliablePersons = value;
                    NotifyOfPropertyChange(nameof(AvaliablePersons));
                }
            }
        }


        public BindableCollection<PersonModel> SelectedPersons
        {
            get { return _selectedPersons; }
            set
            {
                if (_selectedPersons != value)
                {
                    _selectedPersons = value;
                    NotifyOfPropertyChange(nameof(SelectedPersons));
                }
            }
        }

        public JobModel NewJob
        {
            get { return _newjob; }
            set
            {
                if (_newjob != value)
                {
                    _newjob = value;
                }
                NotifyOfPropertyChange(nameof(NewJob));
            }
        }
        
        public NewJobViewModel(IDataAccess data, IEventAggregator eventAggregator)
        {
            _data = data;
            _eventAggregator = eventAggregator;
            Task.Run(() => InitializeData()).Wait();
        }

        private async Task InitializeData()
        {
            AvaliablePersons = new BindableCollection<PersonModel>(await _data.LoadPersonsAsync());
            var sql = "Select * From jobtypes";
            JobType = (await _data.LoadDataSQL<JobTypeModel>(sql)).ToList();
        }

        public void AddPerson()
        {
            if(SelectedPerson != null)
            {
                SelectedPersons.Add(SelectedPerson);
                NewJob.Persons.Add(SelectedPerson);
                AvaliablePersons.Remove(SelectedPerson);

                SelectedPersons.Refresh();
                AvaliablePersons.Refresh();

                SelectedPerson = null;
            }
        }

        public async Task Add()
        {
            if (NewJob.Name == null && NewJob.Description == null && SelectedPersons.Count == 0)
                ErrorMessage = "You have to select all options!";
            else
            {
                var validator = new JobValidator();
                var result = validator.Validate(NewJob);

                if (result.IsValid)
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("Name", NewJob.Name);
                    parameters.Add("Deadline", NewJob.Deadline);
                    parameters.Add("Description", NewJob.Description);
                    parameters.Add("Type", NewJob.Type.Type_ID);
                    parameters.Add("new_id", DbType.Int32, direction: ParameterDirection.Output);

                    try
                    {
                        int newID = await _data.SaveDataSP("sp_NewJob", parameters);
                        NewJob.Job_ID = newID;

                        foreach(var p in NewJob.Persons)
                        {
                            parameters = new DynamicParameters();
                            parameters.Add("PersonID", p.Person_ID);
                            parameters.Add("JobID", NewJob.Job_ID);
                            parameters.Add("new_id", DbType.Int32, direction: ParameterDirection.Output);
                            await _data.SaveDataSP("sp_NewPersonJob", parameters);                            
                        }

                        _eventAggregator.Publish(new NewJobEvent(NewJob));
                        await Clear();
                        ErrorMessage = "";
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

        public async Task Clear()
        {
            if (NewJob.Name == null && NewJob.Description == null && SelectedPersons.Count == 0)
                Close();

            NewJob = new JobModel();
            SelectedPersons = new BindableCollection<PersonModel>();
            SelectedPerson = null;
            AvaliablePersons = new BindableCollection<PersonModel>(await _data.LoadPersonsAsync());
        }
        public void Close()
        {
            this.RequestClose();
        }
    }
}
