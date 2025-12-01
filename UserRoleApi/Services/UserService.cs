using Microsoft.EntityFrameworkCore;
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

        public async Task<object> DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<object> GetAllUser()
        {
            try
            {

                var result = new ResultResponseDto();
                result.message = "Sikeres lekérdezés";
                result.result = await _context.Users.ToListAsync();
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

        public async Task<object> GetAllUserWithRole()
        {
            try
            {

                var result = new ResultResponseDto();
                result.message = "Sikeres lekérdezés";
                result.result = await _context.Users
                    .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                    .Select(x => new
                    {
                        UserName = x.Name,
                        UserRole = x.UserRoles
                    .Select(y => y.Role.Name)
                    })
                    .ToListAsync();
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

        public Task<object> GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<object> UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            throw new NotImplementedException();
        }
    }
}
