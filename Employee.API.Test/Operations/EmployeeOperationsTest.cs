using Employee.API.Controllers;
using Employee.API.Operations;
using Employee.API.Test.MockData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Employee.API.Test.Operations
{
    public class EmployeeOperationsTest
    {
        [Fact]
        public async Task CreateAsync_ShouldCall()
        {
            /// Arrange
            /// 

            var employeeoperation = new Mock<IEmployeeOperation>();
            employeeoperation.Setup(x => x.GetEmployeesByPage("1")).ReturnsAsync(EmployeeMockData.GetEmployees());

            /// Act
            EmployeeOperations op = (EmployeeOperations)employeeoperation.Object;
            var resp = await op.GetEmployeesByPage("1");
            

            /// Assert
            Assert.NotNull(resp);
        }
    }
}
