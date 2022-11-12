using EmployeesApp.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesApp.ViewModels.Factories
{
    public interface IEmployeeViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
