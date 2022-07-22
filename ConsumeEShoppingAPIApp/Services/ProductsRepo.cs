using ConsumeEShoppingAPIApp.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ConsumeEShoppingAPIApp.Services
{
    public class ProductsRepo : IRepo<int, Products>
    {
        private readonly HttpClient _httpClient;
        static string UserName;

        public ProductsRepo()
        {
            _httpClient = new HttpClient();
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
                        return product;
                    }
                }
            }
            return null;
        }

       
        public async Task<Products> Delete(int key)
        {
            throw new NotImplementedException();
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
                        product.UserName = UserName;
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
                        return product;
                    }
                }
            }
            return null;
        }

        public async Task<Products> AddCart(Products item)
        {
            using (var httpClient = new HttpClient())
            {

                try
                {
                    using (var response = await httpClient.PostAsJsonAsync("http://localhost:5154/api/Products/Product_AddingCart", item))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string responseText = await response.Content.ReadAsStringAsync();
                            var product = JsonConvert.DeserializeObject<Products>(responseText);
                            return product;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            return null;
        }

        public async Task<ICollection<Products>> GetAllCart()
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.GetAsync("http://localhost:5154/api/Products/GetAll_Carts"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        int flag = 0;
                        string responseText = await response.Content.ReadAsStringAsync();
                        var products = JsonConvert.DeserializeObject<List<Products>>(responseText);
                        List<Products> proc = new List<Products>();
                        foreach(var item in products)
                        {
                            if(item.UserName ==UserName)
                            {
                                flag++;
                                proc.Add(item);
                            }
                        }
                        if (flag > 0)
                        {
                            return proc;
                        }
                        else
                            return proc;
                    }
                }
            }
            return null;
        }

       
        public Task<Products> AddUserName(string str)
        {
            UserName = str;
            return null;
        }

        public async Task<Products> DeleteProductCart(Products item)
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.PutAsJsonAsync("http://localhost:5154/api/Products/Product_DeleteProductCart", item))
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

        public async Task<Products> AddSameProduct(Products item)
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.PutAsJsonAsync("http://localhost:5154/api/Products/Product_AddSameProductCart", item))
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

        public async Task<Products> DeleteSameProduct(Products item)
        {
            using (_httpClient)
            {
                using (var response = await _httpClient.PutAsJsonAsync("http://localhost:5154/api/Products/Product_DeleteSameProductCart", item))
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
    }
}
