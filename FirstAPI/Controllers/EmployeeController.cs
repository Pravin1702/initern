using FirstAPI.Models;
using FirstAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepo<int, Employee> _repo;

        public EmployeeController(IRepo<int, Employee> repo)
        {
            _repo = repo;
        }
        //Create
        [HttpPost]
        public ActionResult<Employee> Create(Employee employee)
        {
            var emp = _repo.Add(employee);
            if (emp == null)
            {
                return BadRequest("Employee not created");
            }
            return Created("Employee Added", emp);
        }
        //Read
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            var employees = _repo.GetAll().ToList();
            if (employees.Count == 0)
                return NotFound("No employees present");
            return employees;
        }
        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public ActionResult<Employee> GetEmployees(int id)
        {
            var employee = _repo.Get(id);
            if (employee == null)
                return NotFound("No employee with id " + id);
            return Ok(employee);
        }
        //Update
        [HttpPut]
        public ActionResult<Employee> Update(int id, Employee employee)
        {
            var emp = _repo.Update(employee);
            if (emp == null)
                return NotFound("No employee with id " + id);
            return Ok(employee);
        }
        //Delete
        [HttpDelete]
        public ActionResult<Employee> Delete(int id)
        {
            var emp = _repo.Delete(id);
            if (emp == null)
                return NotFound("No employee with id " + id);
            return Ok(emp);
        }
      
    }
}
