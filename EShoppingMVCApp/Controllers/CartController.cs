using EShoppingMVCApp.Models;
using EShoppingMVCApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingMVCApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IRepoCart<Cart> _crepo;

        public CartController(IRepoCart<Cart> crepo)
        {
            _crepo = crepo;
        }
        public async Task<IActionResult> CartIndex()
        {
            var products = await _crepo.GetAll();
            return View(products);
        }

        [HttpGet]
        public async Task<ActionResult> AddCart(int id)
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> AddCart(Cart cart)
        {
            var cartproduct = await _crepo.GetAll();
            return View(cart);
            return RedirectToAction("CartIndex");

        }
    }
}
