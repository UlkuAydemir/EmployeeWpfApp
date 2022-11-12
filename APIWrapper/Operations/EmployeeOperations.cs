using APIWrapper.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIWrapper.Operations
{
    public class EmployeeOperations : IEmployeeOperation
    {
        public EmployeeOperations()
        {
            ApiHelper.InitializeClient();
        }
        public async Task<HttpStatusCode> CreateEmployeeAsync(Employee employee)
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

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            var response = await ApiHelper.ApiClient.GetStringAsync("users");
               
            var employees = JsonConvert.DeserializeObject<List<Employee>>(response);

            return employees;
        }

        public async Task<List<Employee>> GetEmployeeByName(string pageCount, string name)
        {
            var response = await ApiHelper.ApiClient.GetStringAsync($"users?page={pageCount}&name={name}");

            var employees = JsonConvert.DeserializeObject<List<Employee>>(response);

            return employees;
        }

        public async Task<List<Employee>> GetEmployeesByPage(string page)
        {
            var response = await ApiHelper.ApiClient.GetStringAsync("users?page=" + page);

            var employees = JsonConvert.DeserializeObject<List<Employee>>(response);

            return employees;
        }

        public async Task<HttpStatusCode> UpdateEmployee(Employee employee)
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
