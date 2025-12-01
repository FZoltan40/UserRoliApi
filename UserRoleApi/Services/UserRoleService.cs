using UserRoleApi.Models;
using UserRoleApi.Models.Dtos;
using UserRoleApi.Services.IServices;

namespace UserRoleApi.Services
{
    public class UserRoleService : IUserRole
    {
        private readonly UserDbContext _context;
        public UserRoleService(UserDbContext context)
        {
            _context = context;
        }
        public async Task<object> AddNewConnection(AddUserRoleDto addUserRoleDto)
        {
            try
            {
                var result = new ResultResponseDto();

                var userrole = new UserRole
                {
                    UserId = addUserRoleDto.UserId,
                    RoleId = addUserRoleDto.RoleId
                };

                if (userrole != null)
                {
                    await _context.UserRoles.AddAsync(userrole);
                    await _context.SaveChangesAsync();

                    result.message = "Sikeres hozzáadás.";
                    result.result = userrole;

                    return result;
                }

                result.message = "Sikertelen hozzáadás.";
                result.result = userrole;

                return result;

            }
            catch (Exception ex)
            {

                var result = new ResultResponseDto();
                result.message = ex.Message;
                result.result = null;

                return result;
            }
        }
    }
}
