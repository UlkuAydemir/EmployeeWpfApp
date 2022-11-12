using Employee.API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employee.API.Test.MockData
{
    public class EmployeeMockData
    {
        public static List<EmployeeModel> GetEmployees()
        {

            return new List<EmployeeModel>
            {
                new EmployeeModel
                {
                    id = 12,
                    name = "Ulku",
                    email = "ulku@mail",
                    gender = "female",
                    status = "acitve"
                },
                new EmployeeModel
                {
                    id = 13,
                    name = "Cansu",
                    email = "cansu@mail",
                    gender = "female",
                    status = "acitve"
                },
                new EmployeeModel
                {
                    id = 14,
                    name = "Alice",
                    email = "alice@mail",
                    gender = "female",
                    status = "acitve"
                },
                new EmployeeModel
                {
                    id = 15,
                    name = "John",
                    email = "john@mail",
                    gender = "male",
                    status = "acitve"
                }

            };
        }

        public static EmployeeModel NewEmployee()
        {
            return new EmployeeModel
            {
                name = "Emma",
                email = "emma@mail2",
                gender = "female",
                status = "acitve"
            };
        }
    }
}
