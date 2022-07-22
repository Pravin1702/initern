using Newtonsoft.Json;
using ReferFirstAPIapp.Models;

namespace ReferFirstAPIapp.Services
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
                using (var response = await _httpClient.PostAsJsonAsync("http://localhost:2111/api/Employee", item))
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
            
            
            return null;
        }

        public async Task<Employee> Get(int key)
        {
           
            return null;
        }

        public async Task<ICollection<Employee>> GetAll()
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync("http://localhost:2111/api/Employee"))
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
            
            return null;
        }
    }
}

