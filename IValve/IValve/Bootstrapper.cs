using DataAccessLibrary.DbAccess;
using IValve.ViewModel;
using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IValve
{
    public class Bootstrapper : Bootstrapper<RootViewModel>
    {
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            // Rejestracja zależności
            builder.Bind<IDataAccess>().To<DataAccess>();
        }
    }
}
