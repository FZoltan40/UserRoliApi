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
            if (addUserDto != null)
            {
                return StatusCode(201, await _user.AddNewUser(addUserDto));
            }

            return StatusCode(404, await _user.AddNewUser(addUserDto));

        }

        [HttpGet]
        public async Task<ActionResult> GetAllUser()
        {
            var user = await _user.GetAllUser();
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound(user);

        }

    }
}
