using EmployeesApp.State.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeesApp.ViewModels.Factories
{
    public class EmployeeViewModelFactory : IEmployeeViewModelFactory
    {
        private readonly CreateViewModel<EmployeeViewModel> _createEmployeeViewModel;
        private readonly CreateViewModel<ListEmployeeViewModel> _createEmployeeListViewModel;
        private readonly CreateViewModel<UpdateEmployeeViewModel> _createEmployeeUpdateViewModel;


        public EmployeeViewModelFactory(CreateViewModel<EmployeeViewModel> createHomeViewModel,
           CreateViewModel<ListEmployeeViewModel> createEmployeeListViewModel,
           CreateViewModel<UpdateEmployeeViewModel> createEmployeeCreateViewModel
           )
        {
            _createEmployeeViewModel = createHomeViewModel;
            _createEmployeeListViewModel = createEmployeeListViewModel;
            _createEmployeeUpdateViewModel = createEmployeeCreateViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.ListEmployee:
                    return _createEmployeeListViewModel();
                case ViewType.CreateEmployee:
                    return _createEmployeeViewModel();
                case ViewType.UpdateEmployee:
                    return _createEmployeeUpdateViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
