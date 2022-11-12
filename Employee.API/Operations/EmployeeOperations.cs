using Employee.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Employee.API.Operations
{
    public class EmployeeOperations : IEmployeeOperation
    {
        public EmployeeOperations()
        {
            ApiHelper.InitializeClient();
        }
        public async Task<HttpStatusCode> CreateEmployeeAsync(EmployeeModel employee)
        {
            
            var resp = await ApiHelper.ApiClient.PostAsJsonAsync("users", employee);

            if (resp.IsSuccessStatusCode)
            {
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.BadRequest;
            }
        }

        public async Task<HttpStatusCode> DeleteEmployee(int id)
        {
            var resp = await ApiHelper.ApiClient.DeleteAsync("users/" + id);
            if (resp.IsSuccessStatusCode)
            {
                return HttpStatusCode.OK;
            }
            else
            {
                throw new Exception("Exc");
            }
        }

        public async Task<List<EmployeeModel>> GetAllEmployeesAsync()
        {
            var response = await ApiHelper.ApiClient.GetStringAsync("users");
               
            var employees = JsonConvert.DeserializeObject<List<EmployeeModel>>(response);

            return employees;
        }

        public async Task<List<EmployeeModel>> GetEmployeeByName(string pageCount, string name)
        {
            var response = await ApiHelper.ApiClient.GetStringAsync($"users?page={pageCount}&name={name}");

            var employees = JsonConvert.DeserializeObject<List<EmployeeModel>>(response);

            return employees;
        }

        public async Task<List<EmployeeModel>> GetEmployeesByPage(string page)
        {
            var response = await ApiHelper.ApiClient.GetStringAsync("users?page=" + page);

            var employees = JsonConvert.DeserializeObject<List<EmployeeModel>>(response);

            return employees;
        }

        public async Task<HttpStatusCode> UpdateEmployee(EmployeeModel employee)
        {
            var resp = await ApiHelper.ApiClient.PutAsJsonAsync("users/" +employee.id.ToString(), employee);

            if (resp.IsSuccessStatusCode)
            {
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.BadRequest;
            }
        }
    }
}
