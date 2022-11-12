using APIWrapper.Operations;
using Employee.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Employee.Wpf.Commands
{
    public class CreateEmployeeCommand : AsyncCommandBase
    {
        
        private readonly EmployeeViewModel _employeeViewModel;
        private readonly IEmployeeOperation _employeeOperations;

        public CreateEmployeeCommand(EmployeeViewModel employeeViewModel, IEmployeeOperation employeeOperations)
        {
            this._employeeViewModel = employeeViewModel;
            this._employeeOperations = employeeOperations;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                var response = await _employeeOperations.CreateEmployeeAsync(new APIWrapper.Models.Employee
                {

                    email = _employeeViewModel.Email,
                    gender = _employeeViewModel.Gender,
                    name = _employeeViewModel.Name,
                    status = "active",
                    id = _employeeViewModel.Id
                });

                if (response == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Employee Created", "Success");
                }
                else
                {
                    MessageBox.Show(response.ToString(), "Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
           
        }
    }
}
