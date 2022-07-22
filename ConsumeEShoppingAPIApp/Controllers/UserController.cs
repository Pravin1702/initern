using ConsumeEShoppingAPIApp.Models;
using ConsumeEShoppingAPIApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConsumeEShoppingAPIApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepo _repo;
        static string UserName ;
        Products product = new Products();

        public UserController(UserRepo repo)
        {
            _repo = repo;
        }
        public async Task<ActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(User user)
        {
            var usr=await _repo.Login(user);
            if (usr == null)
            {
                ViewBag.Message = "Invalid username or password";
                return View();
            }
            else
            {
                UserName=usr.Name;
                if (usr.Role == "admin")
                {
                    ProductsRepo pro = new ProductsRepo();
                    pro.AddUserName(UserName);
                    return RedirectToAction("Create", "Products");
                }
                else
                {
                    ProductsRepo pro = new ProductsRepo();
                    pro.AddUserName(UserName);
                    return RedirectToAction("Index", "Products");
                }
            }
        }
        public async Task<ActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(User users)
        {
            var emp=await _repo.Register(users);
            return RedirectToAction("Login","User");
        }
    }
}
