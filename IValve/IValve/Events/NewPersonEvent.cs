using IValve.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValve.Events
{
    public class NewPersonEvent
    {
        public PersonModel NewPerson { get; set; }
        public NewPersonEvent(PersonModel person)
        {
            NewPerson = person;
        }
    }
}
