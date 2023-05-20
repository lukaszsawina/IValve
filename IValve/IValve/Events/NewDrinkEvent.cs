using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValve.Events
{
    public class NewDrinkEvent
    {
        public DrinkModel Drink { get; set; }
        public NewDrinkEvent(DrinkModel drink)
        {
            Drink = drink;
        }

    }
}
