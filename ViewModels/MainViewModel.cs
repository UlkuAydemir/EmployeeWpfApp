using EmployeesApp.Commands;
using EmployeesApp.State.Navigators;
using EmployeesApp.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EmployeesApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IEmployeeViewModelFactory _employeeViewModelFactory;
        private readonly INavigator _navigator;

        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(INavigator navigator, IEmployeeViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _employeeViewModelFactory = viewModelFactory;
            

            _navigator.StateChanged += Navigator_StateChanged;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _employeeViewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.ListEmployee);
        }

        private void Navigator_StateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public override void Dispose()
        {
            _navigator.StateChanged -= Navigator_StateChanged;

            base.Dispose();
        }

    }
}
