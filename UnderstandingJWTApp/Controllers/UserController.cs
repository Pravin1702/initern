using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnderstandingJWTApp.Model;
using UnderstandingJWTApp.Services;

namespace UnderstandingJWTApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<UserDTO>> Login(UserDTO user)
        {
            var result = await _userService.Login(user);
            if (result == null)
                return Unauthorized("Invalid username or password");
            return Ok(result);
        }
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<UserDTO>> Register(UserDTO user)
        {
            var result = await _userService.Register(user);
            if (result == null)
                return BadRequest("Unable to register");
            return Ok(result);
        }
    }
}
