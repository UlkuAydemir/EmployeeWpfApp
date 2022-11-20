﻿using APIWrapper.Models;
using APIWrapper.Operations;
using Employee.Wpf.Commands;
using Employee.Wpf.Views;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml.Linq;

namespace Employee.Wpf.ViewModels
{
    public class EmployeeListViewModel : MainViewModel
    {
        private ObservableCollection<EmployeeViewModel> _employees;
        public ObservableCollection<EmployeeViewModel> EmployeeModels
        {
            get
            {
                return _employees;
            }
            set
            {
                _employees = value;
                OnPropertyChanged("EmployeeModels");
            }
        }

        private EmployeeViewModel _selectedEmployee;
        public EmployeeViewModel SelectedEmployee
        {
            get
            {
                return _selectedEmployee;
            }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
            }
        }

        private bool _buttonPreviousEnabled = false; 
        public bool ButtonPreviousEnabled 
        {
            get
            {
                return _buttonPreviousEnabled;
            }
            set
            {
                _buttonPreviousEnabled = value;
                OnPropertyChanged("ButtonPreviousEnabled");
            }
        }

        private string _searchKey;
        public string SearchKey
        {
            get
            {
                return _searchKey;
            }
            set
            {
                _searchKey = value;
                OnPropertyChanged("SearchKey");
            }
        }

        private int _pageCount;
        public int PageCount
        {
            get
            {
                return _pageCount;
            }
            set
            {
                _pageCount = value;
                ButtonPreviousEnabled = _pageCount == 1 ? false : true;
                OnPropertyChanged("PageCount");
            }
        }

        public ICommand _deleteCommand { get; private set; }
        public ICommand _pagingCommand { get; private set; }
        public ICommand _searchCommand { get; private set; }
        public ICommand _updateCommand { get; private set; }

        private IEmployeeOperation _employeeOperation;

        public EmployeeListViewModel()
        {
            _employeeOperation = this.EmployeeOperations;
            PageCount = 1;
            LoadDataGrid();
        }

        public async void LoadDataGrid()
        {
            EmployeeModels = new ObservableCollection<EmployeeViewModel>();
            var response = await _employeeOperation.GetEmployeeByName(PageCount.ToString(), SearchKey);
            if (response != null)
            {
                foreach (var employee in response)
                {
                    EmployeeModels.Add(new EmployeeViewModel()
                    {
                        Id = employee.id,
                        Name = employee.name,
                        Status = employee.status,
                        Email = employee.email,
                        Gender = employee.gender
                    });
                }
            }
        }

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                    _deleteCommand = new AsyncCommandBase(param => DeleteEmployee(((EmployeeViewModel)param).Id));

                return _deleteCommand;
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                    _searchCommand = new AsyncCommandBase(param => SearchEmployee((string)param));

                return _searchCommand;
            }
        }

        public ICommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                    _updateCommand = new AsyncCommandBase(param => UpdateView_Show(((EmployeeViewModel)param)));

                return _updateCommand;
            }
        }

        private void UpdateView_Show(EmployeeViewModel view)
        {
            view.DataChanged += View_DataChanged;

            UpdateEmployeeView windowUpdate = new UpdateEmployeeView();
            windowUpdate.DataContext = view;
            windowUpdate.Show();
        }

        private void View_DataChanged()
        {
             LoadDataGrid();
        }

        public ICommand PagingCommand
        {
            get
            { 
                if (_pagingCommand == null)
                    _pagingCommand = new AsyncCommandBase(param => Paging((string)param));

                return _pagingCommand;
            }
        }

        private void Paging(string page)
        {
            try
            {
                if(page == "next" )
                {
                    PageCount++;
                    LoadDataGrid();
                }
                else if(page == "previous" && PageCount > 1)
                {
                    PageCount--;
                    LoadDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void SearchEmployee(string name)
        {
            try
            {
                PageCount = 1;
                LoadDataGrid();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public async void DeleteEmployee(int id)
        {
            if (MessageBox.Show("Are you sure delete of this employee?", " Delete Employee", MessageBoxButton.YesNo)
                == MessageBoxResult.Yes)
            {
                try
                {
                    var response = await _employeeOperation.DeleteEmployee(id);
                    if (response == System.Net.HttpStatusCode.OK)
                    {
                        MessageBox.Show("Employee Deleted", "Success");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occured while deleting. " + ex.InnerException);
                }
                finally
                {
                    LoadDataGrid();
                }
            }
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
