using APIWrapper.Operations;
using Employee.Wpf.State;
using Employee.Wpf.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Wpf.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public INavigator Navigator { get; set; } = new Navigator();
        public IEmployeeOperation EmployeeOperations { get; set; } = new EmployeeOperations();
    }
}
