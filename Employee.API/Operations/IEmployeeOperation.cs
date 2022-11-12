using Employee.API.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Employee.API.Operations
{
    public interface IEmployeeOperation
    {
        Task<List<EmployeeModel>> GetAllEmployeesAsync();

        Task<List<EmployeeModel>> GetEmployeeByName(string page, string name);

        Task<List<EmployeeModel>> GetEmployeesByPage(string page);

        Task<HttpStatusCode> CreateEmployeeAsync(EmployeeModel task);

        Task<HttpStatusCode> UpdateEmployee(EmployeeModel task);

        Task<HttpStatusCode> DeleteEmployee(int id);
    }
}
