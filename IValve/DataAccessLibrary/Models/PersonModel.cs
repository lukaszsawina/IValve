using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class PersonModel
    {
        public int Person_ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime BirthDate { get; set; }
        public RoleModel? Role { get; set; }
        public StatusModel? Status { get; set; }
        public RoomModel? Room { get; set; }
    }
}
