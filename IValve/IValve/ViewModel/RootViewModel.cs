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
        public RoomViewModel RoomView { get; private set; }
        public RootViewModel(PersonViewModel person, RoomViewModel room)
        {
            PersonView = person;
            RoomView = room;
        }
        public void OpenPerson()
        {
            this.ActivateItem(PersonView);
        }
        public void OpenRooms()
        {
            this.ActivateItem(RoomView);
        }
        public void Close()
        {
            this.RequestClose();
        }
    }
}
