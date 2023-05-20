using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValve.Events
{
    public class NewFoodEvent
    {
        public NewFoodEvent(FoodModel food)
        {
            Food = food;
        }

        public FoodModel Food { get; set; }
    }
}
