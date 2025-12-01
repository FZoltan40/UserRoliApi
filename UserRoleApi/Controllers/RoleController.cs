using Microsoft.AspNetCore.Mvc;
using UserRoleApi.Models.Dtos;
using UserRoleApi.Services.IServices;

namespace UserRoleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRole _role;
        public RoleController(IRole role)
        {
            _role = role;
        }

        [HttpPost]
        public async Task<ActionResult> AddNewRole(AddRoleDto addRoleDto)
        {
            var role = await _role.AddNewRole(addRoleDto);

            if (role != null)
            {
                return StatusCode(201, role);
            }

            return StatusCode(201, null);
        }
    }
}
