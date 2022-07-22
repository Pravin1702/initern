using EShoppingAPIApp.Models;
using EShoppingAPIApp.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCors")]
    public class UserController : ControllerBase
    {
        private readonly UserRepo _repo;

        public UserController(UserRepo repo)
        {
            _repo = repo;
        }
        // Create
        [HttpPost]
        [Route("Register")]

        public ActionResult<User> Create(User user)
        {
            var emp = _repo.Register(user);
            if (emp == null)
            {
                return BadRequest("Employee not created");
            }
            return Created("Employee Added", emp);
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<User> Login(User user)
        {
            var emp = _repo.Login(user);
            if (emp == null)
            {
                return BadRequest("Employee Name or Password Invalide");
            }
            return Created("Employee Loing successfully", emp);
        }
    }
}
