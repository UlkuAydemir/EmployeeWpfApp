using Employee.API.Controllers;
using Employee.API.Operations;
using Employee.API.Test.MockData;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Employee.API.Test.Controllers
{
    public class EmployeeControllerTest
    {
        [Fact]
        public async Task GetAllEmployees_ShouldReturn200Status()
        {
            //Arrange
            var employeeoperation = new Mock<IEmployeeOperation>();
            string page = "1";
            string name = "";
            employeeoperation.Setup(_ => _.GetEmployeeByName(page, name)).ReturnsAsync(EmployeeMockData.GetEmployees());
            var task = new EmployeeController(employeeoperation.Object);

            /// Act
            var result = (OkObjectResult)await task.GetAllEmployees(page,name);


            // /// Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task CreateAsync_ShouldCall()
        {
            /// Arrange
            var employeeoperation = new Mock<IEmployeeOperation>();
            var newEmployee = EmployeeMockData.NewEmployee();
            var task = new EmployeeController(employeeoperation.Object);

            /// Act
            var result = (OkObjectResult)await task.CreateEmployee(null);

            /// Assert
            result.StatusCode.Should().Be(200);
        }
    }
}
