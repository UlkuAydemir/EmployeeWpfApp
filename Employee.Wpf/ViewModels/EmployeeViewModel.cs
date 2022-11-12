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
    public class EmployeeViewModel : BaseViewModel
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

        public ICommand CreateEmployeeCommand { get; }
        public ICommand _updateEmployeeCommand { get; set; }
        private IEmployeeOperation _employeeOperation;

        public EmployeeViewModel(IEmployeeOperation employeeOperations)
        {
            CreateEmployeeCommand = new CreateEmployeeCommand(this, employeeOperations);
            _employeeOperation = employeeOperations;
        }
        public ICommand UpdateEmployeeCommand
        {
            get
            {
                if (_updateEmployeeCommand == null)
                    _updateEmployeeCommand = new RelayCommand(param => UpdateEmployee((EmployeeViewModel)param), null);

                return _updateEmployeeCommand;
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
                }
                
            }
            
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
