using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class JobModel
    {
        public int Job_ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline{ get; set; }
        public JobTypeModel Type { get; set; }
        public List<PersonModel> Persons { get; set; } = new List<PersonModel>();
    }
}
