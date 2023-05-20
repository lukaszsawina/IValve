using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class ItemModel
    {
        public int Item_ID { get; set; } 
        public string Name { get; set; }
        public int Amount { get; set; }
        public SupplyTypeModel Type { get; set; }
    }
}
