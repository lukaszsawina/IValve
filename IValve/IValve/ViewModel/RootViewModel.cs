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
        public LogoViewModel Logo { get; private set; }
        public PersonViewModel PersonView { get; private set; }
        public RoomViewModel RoomView { get; private set; }
        public RootViewModel(LogoViewModel logo, PersonViewModel person, RoomViewModel room, SupplyViewModel supplyView)
        {
            Logo = logo;
            PersonView = person;
            RoomView = room;
            SupplyView = supplyView;
            this.ActivateItem(Logo);
        }
        public void OpenPerson()
        {
            if (!PersonView.IsActive)
                this.ActivateItem(PersonView);
            else
                this.ActivateItem(Logo);

        }
        public void OpenRooms()
        {
            if (!RoomView.IsActive)
                this.ActivateItem(RoomView);
            else
                this.ActivateItem(Logo);

        }
        public void OpenSupply()
        {
            if (!SupplyView.IsActive)
                this.ActivateItem(SupplyView);
            else
                this.ActivateItem(Logo);

        }
        public void Close()
        {
            this.RequestClose();
        }
    }
}
