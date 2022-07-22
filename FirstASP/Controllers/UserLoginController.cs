using FirstASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FirstASP.Controllers
{
    public class UserLoginController : Controller
    {
        static List<UserLogin> userlogin = new List<UserLogin>()
        {
            new UserLogin(){Name="Ramu",Password="Ramu21"},
            new UserLogin(){Name="Somu",Password="Somu22"},
            new UserLogin(){Name="Bimu",Password="Bimu24"}
        };
        
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLogin userslogin)
        {
            var user = userlogin.SingleOrDefault(emp => emp.Name == userslogin.Name && emp.Password == userslogin.Password);
            if (user != null)
            {
                ViewBag.Message = " Welcome " + userslogin.Name;
            }
            else
                ViewBag.Message = "Invalid username or Password ";
            return View();
        }
    }
}
