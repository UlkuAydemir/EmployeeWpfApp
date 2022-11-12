using Employee.API.Models;
using Employee.API.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Employee.API.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeOperation _employeeOperation;

        public EmployeeController(IEmployeeOperation employeeOperation)
        {
            _employeeOperation = employeeOperation;
        }

        public async Task<IActionResult> GetAllEmployees(string page, string name)
        {
            var result = await _employeeOperation.GetEmployeeByName(page, name);

            if (result.Count == 0)
            {
                return NoContent();
            }

            return Ok(result);
        }

        public async Task<IActionResult> CreateEmployee(EmployeeModel model)
        {
            var result = await _employeeOperation.CreateEmployeeAsync(model);

            return Ok(result);
        }

    }
}
