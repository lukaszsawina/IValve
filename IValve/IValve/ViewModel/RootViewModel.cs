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
        public SupplyViewModel SupplyView { get; private set; }
        public PersonViewModel PersonView { get; private set; }
        public RoomViewModel RoomView { get; private set; }
        public RootViewModel(PersonViewModel person, RoomViewModel room, SupplyViewModel supplyView)
        {
            PersonView = person;
            RoomView = room;
            SupplyView = supplyView;
        }
        public void OpenPerson()
        {
            this.ActivateItem(PersonView);
        }
        public void OpenRooms()
        {
            this.ActivateItem(RoomView);
        }
        public void OpenSupply()
        {
            this.ActivateItem(SupplyView);
        }
        public void Close()
        {
            this.RequestClose();
        }
    }
}
