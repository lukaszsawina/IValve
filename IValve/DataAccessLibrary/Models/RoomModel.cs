using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class RoomModel
    {
        public int? Room_ID { get; set; }
        public SectionModel? Section { get; set; }
        public int? Capacity { get; set; }
        public int Occupied { get; set; }
        public string FullCapacity 
        { 
            get
            {
                return $"{Occupied} / {Capacity}";
            }
        }
    }
}
