using Employee.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Employee.Wpf.State.Navigators
{
    public enum ViewType
    {
        Employee,
        ListEmployee
    }
    public interface INavigator
    {
        BaseViewModel CurrentViewModel { get; set; }
        ICommand UpdateCurrenViewModelCommand { get; }
    }
}
