using APIWrapper.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIWrapper.Operations
{
    public interface IEmployeeOperation
    {
        Task<List<Employee>> GetAllEmployeesAsync();

        Task<List<Employee>> GetEmployeeByName(string pageCount, string name);

        Task<List<Employee>> GetEmployeesByPage(string page);

        Task<HttpStatusCode> CreateEmployeeAsync(Employee task);

        Task<HttpStatusCode> UpdateEmployee(Employee task);

        Task<HttpStatusCode> DeleteEmployee(int id);
    }
}
