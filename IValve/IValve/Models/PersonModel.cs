using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValve.Models
{
    public class PersonModel
    {
        public int Person_ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public int? Role { get; set; }
        public int? Status { get; set; }
        public int? Room { get; set; }
    }
}
