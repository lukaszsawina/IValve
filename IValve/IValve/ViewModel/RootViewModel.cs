using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValve.ViewModel
{

    
    public class RootViewModel : Conductor<IScreen>.StackNavigation
    {
        public PersonViewModel PersonView { get; private set; }
        public Test2ViewModel Test2 { get; private set; }
        public RootViewModel(PersonViewModel person, Test2ViewModel test2)
        {
            PersonView = person;
            Test2 = test2;
            this.ActivateItem(PersonView);
        }
        public void OpenPerson()
        {
            this.ActivateItem(PersonView);
        }
        public void OpenRooms()
        {
            this.ActivateItem(Test2);
        }
        public void Close()
        {
            this.RequestClose();
        }
    }
}
