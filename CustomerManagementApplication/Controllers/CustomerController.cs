using CustomerManagementApplication.Models;
using CustomerManagementApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementApplication.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRepo<int, Customer> _customerRepo;

        public CustomerController(IRepo<int, Customer> customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public IActionResult Index()
        {
            var customers = _customerRepo.GetAll();
            return View(customers);
        }
        public IActionResult Details(int id)
        {
            var customer = _customerRepo.Get(id);
            return View(customer);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            customer.Pic = "/images/" + customer.Pic;
            var cust = _customerRepo.Add(customer);
            if (cust != null)
                return RedirectToAction("Index");
            return View();
        }
    }
}
