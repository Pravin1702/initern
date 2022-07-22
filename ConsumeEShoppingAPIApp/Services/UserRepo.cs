using ConsumeEShoppingAPIApp.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ConsumeEShoppingAPIApp.Services
{
    public class UserRepo
    {
        private readonly HttpClient _httpClient;

        public UserRepo()
        {
            _httpClient = new HttpClient();
        }
        public async Task<User> Login(User item)
        {
            item.Role = "";
            using (_httpClient)
            {
                using (var response = await _httpClient.PostAsJsonAsync("http://localhost:5154/api/User/Login", item))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var user = JsonConvert.DeserializeObject<User>(responseText);
                        return user;
                    }
                }
            }
            return null;
        }

        public async Task<User> Register(User item)
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.PostAsJsonAsync("http://localhost:5154/api/User/Register", item))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var user = JsonConvert.DeserializeObject<User>(responseText);
                        return user;
                    }
                }
            }
            return null;
        }
    }
}
