using Employee.Wpf.ViewModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using APIWrapper.Operations;
using Moq;
using System.Net;
using Employee.Wpf.Views;

namespace Employee.Test.Tests
{
    public class EmployeeOperationsUnitTest
    {
        [Test]
        public async Task EmployeeListFirstData_Test_Success()
        {
            // Arrange
            var EmployeeService = new EmployeeOperations();
            var viewModel = GetViewModel();
            var EmployeeModels = new List<APIWrapper.Models.Employee>();

            // Act
            var actualEmployeeData = viewModel.EmployeeModels;
            Thread.Sleep(500);
            var expectedEmployeeData = await EmployeeService.GetEmployeeByName("0", string.Empty);

            foreach (var employee in actualEmployeeData)
            {
                EmployeeModels.Add(new APIWrapper.Models.Employee
                {
                    id = employee.Id,
                    name = employee.Name,
                    status = employee.Status,
                    email = employee.Email,
                    gender = employee.Gender
                });
            }
            // Assert
            Assert.AreEqual(expectedEmployeeData.First().name, EmployeeModels.First().name);
        }
        private EmployeeListViewModel GetViewModel()
        {
            return new EmployeeListViewModel();
        }

        [Test]
        public void Test_ButtonPreviousEnabled_Status_FirstPageReturnFalse()
        {
            // Arrange
            var viewModel = GetViewModel();
            // Act
            viewModel.PageCount = 1;
            // Assert
            Assert.AreEqual(false, viewModel.ButtonPreviousEnabled);
        }

        [Test]
        public void Test_ButtonPreviousEnabled_Status_SecondPageReturnTrue()
        {
            // Arrange
            var viewModel = GetViewModel();
            // Act
            viewModel.PageCount = 2;
            // Assert
            Assert.AreEqual(true, viewModel.ButtonPreviousEnabled);
        }
        [Test]
        public void GetAllEmployeesByPage_Returns_List_Of_Employee()
        {
            //ülkü
            //Arrange
            var mockEmployeeOperation = new Mock<IEmployeeOperation>();
            var viewModel = GetViewModel();
            //Act
            mockEmployeeOperation
                .Setup(x => x.GetEmployeesByPage("1"))
                .ReturnsAsync(new List<APIWrapper.Models.Employee> { new APIWrapper.Models.Employee { name = "ulku", email = "ulku@mail", gender = "female", id = 0, status ="inactive"} });
            
            viewModel.EmployeeOperations = mockEmployeeOperation.Object;
            var result = viewModel.EmployeeModels;
            Thread.Sleep(500);

            //Assert
            Assert.AreEqual(1, result.Count);

        }
    }
}
