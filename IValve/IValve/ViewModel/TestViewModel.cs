using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValve.ViewModel
{
    public class TestViewModel : Screen
    {
        public void Close()
        {
            this.RequestClose();
        }
    }
}
