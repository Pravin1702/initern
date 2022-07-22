using Microsoft.AspNetCore.Mvc;
using PizzaApplication.Models;
using PizzaApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApplication.Controllers
{
    public class PizzaController : Controller
    {
        static List<Pizza> Carts = new List<Pizza>()
        {

        };
        private readonly IRepo<int, Pizza> _PizzaRepo;
        public PizzaController(IRepo<int, Pizza> pizzaRepo)
        {
            _PizzaRepo = pizzaRepo;
        }
        public IActionResult Index()
        {
            var pizzas = _PizzaRepo.GetAll();
            return View(pizzas);
        }
        public IActionResult Details(int id)
        {
            var pizzass = _PizzaRepo.Get(id);
            return View(pizzass);
        }
        public IActionResult Cart(int id)
        {
            int flag = 0;
            var pizzass = _PizzaRepo.Get(id);
            foreach(var item in Carts)
            {
                if(item.Id==pizzass.Id)
                {
                    item.Count++;
                    flag++;
                    item.Price = item.Price + pizzass.Price;
                    break;
                }
            }
            if(flag==0)
            {
                pizzass.Count = +1;
                Carts.Add(pizzass);
            }
            
            return View(pizzass);
        }
        public IActionResult CartAll(int id)
        {
            return View(Carts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            pizza.Pic = "/images/" + pizza.Pic;
            var cust = _PizzaRepo.Add(pizza);
            if (cust != null)
                return RedirectToAction("Index");
            return View();
        }
    }
}
