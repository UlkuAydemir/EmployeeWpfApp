using APIWrapper.Operations;
using Employee.Wpf.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Linq;

namespace Employee.Wpf.ViewModels
{
    public class EmployeeViewModel : MainViewModel
    {
        public delegate void DataChangedEventHandler();
        public event DataChangedEventHandler DataChanged;
        public enum GenderEnum
        {
            male,
            female
        }

        private string _gender;
        public string Gender
        {
            get
            {
                return _gender;
            }

            set
            {
                _gender = value;
                OnPropertyChanged("Gender");
            }
        }

        public string[] Genders
        {
            get
            {
                return Enum.GetNames(typeof(GenderEnum));
            }
        }

        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        private string _status;
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        public ICommand _updateEmployeeCommand { get; set; }
        public ICommand _createEmployeeCommand { get; set; }

        private IEmployeeOperation _employeeOperation;

        public EmployeeViewModel()
        {
            _employeeOperation = this.EmployeeOperations;
            
        }
        public ICommand UpdateEmployeeCommand
        {
            get
            {
                if (_updateEmployeeCommand == null)
                    _updateEmployeeCommand = new AsyncCommandBase(param => UpdateEmployee((EmployeeViewModel)param), null);

                return _updateEmployeeCommand;
            }
        }
        public ICommand CreateEmployeeCommand
        {
            get
            {
                if (_createEmployeeCommand == null)
                    _createEmployeeCommand = new AsyncCommandBase(param => CreateEmployee(), null);

                return _createEmployeeCommand;
            }
        }
        private async void UpdateEmployee(EmployeeViewModel view)
        {
            if (MessageBox.Show("Are you sure you want to update this employee?", "Update Employee", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                DataChangedEventHandler handler = DataChanged;
                if (handler != null)
                {
                    
                    var response = await _employeeOperation.UpdateEmployee(
                        new APIWrapper.Models.Employee { 
                                    name = this.Name, 
                                    email=this.Email, 
                                    gender = this.Gender, 
                                    id = this.Id, 
                                    status = this.Status
                            });

                    if (response == System.Net.HttpStatusCode.OK)
                    {
                        handler();
                        MessageBox.Show("Employee Updated", "Success");
                    }
                    else
                    {
                        MessageBox.Show(response.ToString(), "Error");
                    }
                }
                
            }
        }

        public async void CreateEmployee()
        {
            try
            {
                var response = await _employeeOperation.CreateEmployeeAsync(new APIWrapper.Models.Employee
                {

                    email = this.Email,
                    gender = this.Gender,
                    name = this.Name,
                    status = "active",
                    id = this.Id
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

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
