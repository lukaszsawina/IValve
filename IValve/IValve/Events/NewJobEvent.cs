using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValve.Events
{
    public class NewJobEvent
    {
        public NewJobEvent(JobModel newJob)
        {
            NewJob = newJob;
        }

        public JobModel NewJob { get; set; }
    }
}
