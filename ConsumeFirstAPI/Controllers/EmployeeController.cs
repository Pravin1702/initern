using ConsumeFirstAPI.Models;
using ConsumeFirstAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeFirstAPI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IRepo<int, Employee> _repo;

        public EmployeeController(IRepo<int, Employee> repo)
        {
            _repo = repo;
        }
        public async Task<ActionResult> Index()
        {
            var employees = await _repo.GetAll();
            return View(employees);
        }
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Employee employee)
        {
            await _repo.Add(employee);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var employee = await _repo.Get(id);
            return View(employee);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int id, Employee employee)
        {
            await _repo.Update(employee);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var employee = await _repo.Get(id);
            return View(employee);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Employee employee)
        {
            await _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
