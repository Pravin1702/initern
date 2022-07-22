using APILoginAPP.Models;
using APILoginAPP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace APILoginAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepo<string, User> _repo;

        public UserController(IRepo<string, User> repo)
        {
            _repo = repo;
        }
       // Create
        [HttpPost]
        [Route("Register")]

        public ActionResult<User> Create(User user)
        {
            var emp = _repo.Add(user);
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
            var emp = _repo.Get(user);
            if (emp == null)
            {
                return BadRequest("Employee Name or Password Invalide");
            }
            return Created("Employee Loing successfully", emp);
        }


    }
}
