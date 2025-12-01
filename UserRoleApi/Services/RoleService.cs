using UserRoleApi.Models;
using UserRoleApi.Models.Dtos;
using UserRoleApi.Services.IServices;

namespace UserRoleApi.Services
{
    public class RoleService : IRole
    {
        private readonly UserDbContext _context;
        public RoleService(UserDbContext context)
        {
            _context = context;
        }
        public async Task<object> AddNewRole(AddRoleDto addRoleDto)
        {
            var result = new ResultResponseDto();
            try
            {
                var role = new Role
                {
                    Id = Guid.NewGuid(),
                    Name = addRoleDto.Name,
                };

                if (role != null)
                {
                    await _context.Roles.AddAsync(role);
                    await _context.SaveChangesAsync();

                    result.message = "Sikeres hozáadás";
                    result.result = role;
                    return result;
                }

                result.message = "Sikertelen hozáadás";
                result.result = role;
                return result;
            }
            catch (Exception ex)
            {
                result.message = ex.Message;
                result.result = null;
                return result;
            }
        }
    }
}
