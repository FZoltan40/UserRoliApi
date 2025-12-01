using Microsoft.AspNetCore.Mvc;
using UserRoleApi.Models.Dtos;
using UserRoleApi.Services.IServices;

namespace UserRoleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }

        [HttpPost]
        public async Task<ActionResult> AddNewUser(AddUserDto addUserDto)
        {
            var newuser = await _user.AddNewUser(addUserDto);
            if (newuser != null)
            {
                return StatusCode(201, newuser);
            }

            return StatusCode(404, null);

        }

        [HttpGet]
        public async Task<ActionResult> GetAllUser()
        {
            var user = await _user.GetAllUser();
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound(null);

        }

        [HttpGet("allUserWithRoles")]
        public async Task<ActionResult> GetAllUserWithRole()
        {
            var user = await _user.GetAllUserWithRole();
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound(null);

        }

    }
}
