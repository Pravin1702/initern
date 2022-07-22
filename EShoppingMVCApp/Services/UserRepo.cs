using EShoppingMVCApp.Models;
using Newtonsoft.Json;

namespace EShoppingMVCApp.Services
{
    public class UserRepo : IRepo<string, User>
    {
        private readonly HttpClient _httpClient;

        public UserRepo()
        {
            _httpClient = new HttpClient();
        }

        public Task<User> DeleteUser(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Login(User item)
        {
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

        public Task<User> UpdatePassword(User item)
        {
            throw new NotImplementedException();
        }
    }
}
