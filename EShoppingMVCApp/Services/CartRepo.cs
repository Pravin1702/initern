using EShoppingMVCApp.Models;
using Newtonsoft.Json;

namespace EShoppingMVCApp.Services
{
    public class CartRepo : IRepoCart<Cart>
    {
        private readonly HttpClient _httpClient;

        public CartRepo()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Cart> Add(Cart item)
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.PostAsJsonAsync("http://localhost:5154/api/Products/Product_Adding", item))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var product = JsonConvert.DeserializeObject<Cart>(responseText);
                        return product;
                    }
                }
            }
            return null;
        }

        public Task<Cart> Delete(Cart item)
        {
            throw new NotImplementedException();
        }

        public Task<Cart> Get(Cart item)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Cart>> GetAll()
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync("http://localhost:5154/api/Products/GetAll_Products"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var products = JsonConvert.DeserializeObject<List<Cart>>(responseText);
                        return products;
                    }
                }
            }
            return null;
        }

        public Task<Cart> Update(Cart item)
        {
            throw new NotImplementedException();
        }
    }
}
