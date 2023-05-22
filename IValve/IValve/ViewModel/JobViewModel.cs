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
    public class JobViewModel : Screen, IHandle<NewJobEvent>
    {
        private readonly IDataAccess _data;
        private readonly IWindowManager _window;
        private readonly NewJobViewModel _newJobView;
        private readonly IEventAggregator _eventAggregator;
        private BindableCollection<JobModel> _jobs = new BindableCollection<JobModel>();
        private JobModel _selectedJob = new JobModel();

        public JobModel SelectedJob
        {
            get { return _selectedJob; }
            set
            {
                if (_selectedJob != value)
                {
                    _selectedJob = value;
                    NotifyOfPropertyChange(nameof(SelectedJob));
                }
            }
        }

        public BindableCollection<JobModel> Jobs
        {
            get { return _jobs; }
            set
            {
                if (_jobs != value)
                {
                    _jobs = value;
                    NotifyOfPropertyChange(nameof(Jobs));
                }
            }

        }


        public JobViewModel(IDataAccess data, IWindowManager window, NewJobViewModel newJobView, IEventAggregator eventAggregator)
        {
            _data = data;
            _window = window;
            _newJobView = newJobView;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            Task.Run(() => InitializeData()).Wait();
        }

        private async Task InitializeData()
        {
            Jobs = new BindableCollection<JobModel>((await _data.LoadJobsAsync()).ToList().OrderBy(x => x.Job_ID));
        }
        public void Handle(NewJobEvent job)
        {
            Jobs.Add(job.NewJob);
            Jobs.Refresh();
        }
        public void ChangeSelectedJob(object sender, SelectedCellsChangedEventArgs e)
        {
            if (e.AddedCells.Count != 0)
                SelectedJob = (JobModel)e.AddedCells[0].Item;
            else
                SelectedJob = null;
        }

        public void Add()
        {
            _window.ShowWindow(_newJobView);
        }
    }
}
