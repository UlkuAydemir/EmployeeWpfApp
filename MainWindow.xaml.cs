using APIWrapper;
using APIWrapper.Models;
using APIWrapper.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeesApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IEmployeeOperation _employeeOperation;
        public MainWindow()
        {
            InitializeComponent();
           
            _employeeOperation = new EmployeeOperations();
        }
         
        private async void Button_GetEmployees(object sender, RoutedEventArgs e)
        {
            await GetEmployees();
        }

        private async Task GetEmployees()
        {
            var resp = await _employeeOperation.GetAllEmployeesAsync();
           //dgEmployees.DataContext = resp;
        }

        private void btnUpdateEmployee(object sender, RoutedEventArgs e)
        {
            Employee employee = ((FrameworkElement)sender).DataContext as Employee;
            //txtName.Text = employee.name;
            //txtEmail.Text = employee.email;
            //txtEmployeeId.Text = employee.id.ToString();
        }

        private async void btnDeleteEmployee(object sender, RoutedEventArgs e)
        {
            Employee employee = ((FrameworkElement)sender).DataContext as Employee;
            var respDel = await _employeeOperation.DeleteEmployee(employee.id);
            if (respDel == HttpStatusCode.OK)
            {
                await GetEmployees();
            }
        }

        private async void btnCreateEmployee(object sender, RoutedEventArgs e)
        {
            var employee = new Employee
            {
                //name = txtName.Text,
                //email = txtEmail.Text,
                //gender = cmbGender.Text,
                status = "active",
                //id = Int32.Parse(txtEmployeeId.Text)

            };

            if (employee.id == 0)
            {
                var respCreate = await _employeeOperation.CreateEmployeeAsync(employee);
                if (respCreate == HttpStatusCode.OK)
                {
                    await GetEmployees();
                    //lblMessage.Content = "Employee Saved";
                }
            }
            else
            {
                var respUpdate = await _employeeOperation.UpdateEmployee(employee);
                if (respUpdate == HttpStatusCode.OK)
                {
                    await GetEmployees();
                    //lblMessage.Content = "Employee Updated";
                }
            }
            //txtEmployeeId.Text = 0.ToString();
            //txtName.Text = "";
            //txtEmail.Text = "";
            //cmbGender.Text = "";
        }
    }
}
