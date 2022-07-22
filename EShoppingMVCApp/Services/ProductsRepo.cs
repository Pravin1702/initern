using EShoppingMVCApp.Models;
using Newtonsoft.Json;

namespace EShoppingMVCApp.Services
{
    public class ProductsRepo : IReopProducts<int, Products>
    {
        private readonly HttpClient _httpClient;

        List<Products> Pro;

        public ProductsRepo()
        {
            _httpClient = new HttpClient();
            Pro = new List<Products>();
        }

        public async Task<Products> Add(Products item)
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.PostAsJsonAsync("http://localhost:5154/api/Products/Product_Adding", item))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var product = JsonConvert.DeserializeObject<Products>(responseText);
                        Pro.Add(product);
                        return product;
                    }
                }
            }
            return null;
        }

        public Task<Products> Delete(int key)
        {
            
            return null;
        }

        public async Task<Products> Get(int key)
        {

            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync("http://localhost:5154/api/Products/GetProductsById/" + key))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var product = JsonConvert.DeserializeObject<Products>(responseText);
                        return product;
                    }
                }
            }
            return null;
        }

        public async Task<ICollection<Products>> GetAll()
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync("http://localhost:5154/api/Products/GetAll_Products"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var products = JsonConvert.DeserializeObject<List<Products>>(responseText);
                        return products;
                    }
                }
            }
            return null;
        }

        public async Task<Products> Update(Products item)
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.PutAsJsonAsync("http://localhost:5154/api/Employee?id=" + item.Id, item))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseText = await response.Content.ReadAsStringAsync();
                        var product = JsonConvert.DeserializeObject<Products>(responseText);
                        product.Id=101;
                        return product;
                    }
                }
            }
            return null;
        }
    }
}
