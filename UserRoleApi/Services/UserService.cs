using UserRoleApi.Models;
using UserRoleApi.Models.Dtos;
using UserRoleApi.Services.IServices;

namespace UserRoleApi.Services
{
    public class UserService : IUser
    {
        private readonly UserDbContext _context;
        public UserService(UserDbContext context)
        {
            _context = context;
        }
        public async Task<object> AddNewUser(AddUserDto addUserDto)
        {
            try
            {
                var result = new ResultResponseDto();

                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Name = addUserDto.Name,
                    Email = addUserDto.Email,
                    Password = addUserDto.Password
                };


                if (user != null)
                {
                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();

                    result.message = "Sikeres hozzáadás.";
                    result.result = user;

                    return result;
                }

                result.message = "Sikertelen hozzáadás.";
                result.result = user;

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
