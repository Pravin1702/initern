using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaApplication.Models;
using PizzaApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepo _userRepo;

        public UserController(UserRepo userRepo)
        {
            _userRepo = userRepo;
        }
        [HttpGet]
        public IActionResult Login()
        {

            if (TempData.Peek("un") != null)
            {
                ViewBag.UN = TempData["un"];
                ViewBag.Role = HttpContext.Session.GetString("Role");
            }
            else
                ViewBag.UN = "";
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var usr = _userRepo.Login(user);
            if (usr == null)
            {
                ViewBag.Message = "Invalid username or password";
                return View();
            }
            else
            {
                HttpContext.Session.SetString("Role", usr.Role);
                if (usr.Role == "admin")
                    return RedirectToAction("Create", "Pizza");
                else
                    return RedirectToAction("Index", "Pizza");
            }
        }
        public IActionResult Register()
        {
            List<SelectListItem> roles = new List<SelectListItem>()
            {
                new SelectListItem{Text="Select",Value=""},
                new SelectListItem{Text="Admin",Value="admin"},
                new SelectListItem{Text="User",Value="user"}
            };
            ViewBag.Roles = roles;
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserVM user)
        {
            User myUser = new User()
            {
                Username = user.Username,
                Password = user.Password,
                Role = user.Role
            };
            if (_userRepo.Register(myUser) != null)
            {
                TempData["un"] = user.Username;
                HttpContext.Session.SetString("Role", user.Role);
                return RedirectToAction("Login");
            }
            return View();
        }
    }
}
