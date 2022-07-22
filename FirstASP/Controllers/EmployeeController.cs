using FirstASP.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstASP.Controllers
{
    public class EmployeeController : Controller
    {
        static List<Employee> employees = new List<Employee>()
        {
            new Employee(){Id=101,Name="Ramu",Age=21},
            new Employee(){Id=102,Name="Somu",Age=24},
            new Employee(){Id=103,Name="Bimu",Age=28}
        };
        public IActionResult Index()
        {
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            employees.Add(employee);
            return View();
        }
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login(Employee employee)
        {
            var user = employees.SingleOrDefault(emp => emp.Id == employee.Id && emp.Name == employee.Name);
            if (user != null)
            {
                ViewBag.Message = "Welcome " + employee.Name;
            }
            else
                ViewBag.Message = "WInvalid username or password";
            return View();
        }

    }
}
