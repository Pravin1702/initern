using ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBLibrary
{
    public class ProductBL
    {
        private readonly Repo<string, Product> _repo;

        public ProductBL()
        {

        }
        public ProductBL(Repo<string, Product> repo)
        {
            _repo = repo;
        }
        public List<Product> GetAllProducts()
        {
            return _repo.GetAll().ToList();
        }
        public Product GetProductByName(string name)
        {
            Product product = new Product();
            product.Name = name;
            return _repo.Get(product);
        }
    }
}