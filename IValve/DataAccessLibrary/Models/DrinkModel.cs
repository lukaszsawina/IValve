using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class DrinkModel
    {
        public int Drink_ID { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public SupplyTypeModel Type { get; set; }
    }
}
