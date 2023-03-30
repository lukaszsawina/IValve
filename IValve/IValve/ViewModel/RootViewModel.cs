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
        //private IWindowManager _windowManager;
        public Test1ViewModel Test1 { get; private set; }
        public Test2ViewModel Test2 { get; private set; }
        public RootViewModel(Test1ViewModel test, Test2ViewModel test2)
        {
            Test1 = test;
            Test2 = test2;
            this.ActivateItem(Test1);
        }
        public void Strona1()
        {
            this.ActivateItem(Test1);
        }
        public void Strona2()
        {
            this.ActivateItem(Test2);
        }
        //public void ShowAWindow()
        //{
        //    var viewModel = new TestViewModel();
        //    _windowManager.ShowWindow(viewModel);
        //}

        //public string tekst { get; set; } = "Hello world";
        //public void DoSomething()
        //{
        //    tekst = "Hello water";
        //}
    }
}
