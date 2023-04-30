using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValve.Models
{
    public class FullPersonModel
    {
        public int Person_ID { get; init; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public string Room { get; set; }
    }
}
