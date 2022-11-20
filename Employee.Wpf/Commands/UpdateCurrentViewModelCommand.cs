using APIWrapper.Operations;
using Employee.Wpf.State.Navigators;
using Employee.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Employee.Wpf.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private INavigator _navigator;
        private EmployeeViewModel _viewModel { get; set; }

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
            _navigator.CurrentViewModel = new EmployeeViewModel();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Employee:
                        _navigator.CurrentViewModel = new EmployeeViewModel();
                        break;
                    case ViewType.ListEmployee:
                        _navigator.CurrentViewModel = new EmployeeListViewModel();
                        break;
                    default:
                        _navigator.CurrentViewModel = new EmployeeViewModel();
                        break;
                }

            }
        }
    }
}
