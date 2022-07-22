using ConsumeEShoppingAPIApp.Models;
using ConsumeEShoppingAPIApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeEShoppingAPIApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IRepo<int, Products> _repo;
        static int Total;
       
        public ProductsController(IRepo<int, Products> repo)
        {
            _repo = repo;
        }
        [HttpGet]

        public async Task<ActionResult> Index()
        {
            var products = await _repo.GetAll();
            return View(products);
        }
        [HttpGet]

        public async Task<ActionResult> Details(int id)
        {
            var product =await _repo.Get(id);
            return View(product);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Products product)
        {
            await _repo.Add(product);
            return RedirectToAction("Index");
        }

        [HttpPut]
        public async Task<ActionResult<Products>> Update(int id)
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<Products>> Update(int id, Products product)
        {
            await _repo.Update(product);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _repo.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> AddCart(int id)
        {
            var product =await _repo.Get(id);
            Products products=product;
            if (product.Count>1)
            {
                product.Count++;
                products = await _repo.AddSameProduct(product);
                return View(products);

            }
            else if(product.Count==null)
            {
                product.Count=1;
                products = await _repo.AddCart(product);
                return View(products);

            }
            return null;

        }
        [HttpGet]

        public async Task<ActionResult> ViewCart()
        {
             Total = 0;
            var products = await _repo.GetAllCart();
            foreach(var item in products)
            {
                Total = Total + item.Price;
                item.Total = Total;
            }
            return View(products);
        }

        [HttpDelete]

        public async Task<ActionResult> DeleteCart(int id)
        {
            var product = await _repo.Get(id);
            var products = product;
            if (product.Count > 1)
            {
                product.Count++;
                products = await _repo.DeleteSameProduct(product);
                return RedirectToAction("Index");

            }
            else if (product.Count == 1)
            {
                product.Count++;
                products = await _repo.DeleteProductCart(product);
                return RedirectToAction("Index");

            }
            return null;
        }


    }
}
