using EmployeesApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesApp.State.Navigators
{
    public enum ViewType
    {
        ListEmployee,
        CreateEmployee,
        UpdateEmployee
            
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        event Action StateChanged;
    }
    
}
