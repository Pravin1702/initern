using EShoppingMVCApp.Models;
using EShoppingMVCApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingMVCApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepo<string, User> _repo;

        public UserController(IRepo<string, User> repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(User user)
        {
            await _repo.Login(user);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(User user)
        {
            await _repo.Register(user);
            return RedirectToAction("Index");
        }
    }
}
