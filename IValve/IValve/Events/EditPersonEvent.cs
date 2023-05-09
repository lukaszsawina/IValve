using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValve.Events
{
    public class EditPersonEvent
    {
        public PersonModel NewPerson { get; set; }
        public EditPersonEvent(PersonModel person)
        {
            NewPerson = person;
        }
    }
}
