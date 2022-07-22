using ConsumeFirstAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ConsumeFirstAPI.Services
{
    public class EmployeeRepo : IRepo<int, Employee>
    {
        private readonly HttpClient _httpClient;

        public EmployeeRepo()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Employee> Add(Employee item)
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.PostAsJsonAsync("http://localhost:5100/api/Employee", item))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var employee = JsonConvert.DeserializeObject<Employee>(responseText);
                        return employee;
                    }
                }
            }
            return null;
        }

        public async Task<Employee> Delete(int key)
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.DeleteAsync("http://localhost:5100/api/Employee?id=" + key))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var employee = JsonConvert.DeserializeObject<Employee>(responseText);
                        return employee;
                    }
                }
            }
            return null;
        }

        public async Task<Employee> Get(int key)
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync("http://localhost:5100/api/Employee/GetEmployeeById/" + key))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var employee = JsonConvert.DeserializeObject<Employee>(responseText);
                        return employee;
                    }
                }
            }
            return null;
        }

        public async Task<ICollection<Employee>> GetAll()
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync("http://localhost:5100/api/Employee"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var employees = JsonConvert.DeserializeObject<List<Employee>>(responseText);
                        return employees;
                    }
                }
            }
            return null;
        }

        public async Task<Employee> Update(Employee item)
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.PutAsJsonAsync("http://localhost:5100/api/Employee?id=" + item.Id, item))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var employee = JsonConvert.DeserializeObject<Employee>(responseText);
                        return employee;
                    }
                }
            }
            return null;
        }
    }
}
