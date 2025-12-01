using UserRoleApi.Models.Dtos;

namespace UserRoleApi.Services.IServices
{
    public interface IUser
    {
        Task<object> AddNewUser(AddUserDto addUserDto);
    }
}
