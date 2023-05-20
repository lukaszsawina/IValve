using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValve.Events
{
    public class NewItemEvent
    {
        public NewItemEvent(ItemModel item)
        {
            Item = item;
        }

        public ItemModel Item { get; set; }
    }
}
