using EShoppingMVCApp.Models;
using EShoppingMVCApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingMVCApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IReopProducts<int, Products> _repo;

        static List<Cart> Carts = new List<Cart>();

        public ProductsController(IReopProducts<int, Products> repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _repo.GetAll();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var pizzass = _repo.Get(id);
            return View(pizzass);
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
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var product = await _repo.Get(id);
            return View(product);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Products product)
        {
            await _repo.Update(product);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var employee = await _repo.Get(id);
            return View(employee);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Products product)
        {
            await _repo.Delete(id);
            return RedirectToAction("Index");
        }

       
       
        
    }
}
