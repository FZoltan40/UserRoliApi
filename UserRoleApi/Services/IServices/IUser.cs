using UserRoleApi.Models.Dtos;

namespace UserRoleApi.Services.IServices
{
    public interface IUser
    {
        Task<object> AddNewUser(AddUserDto addUserDto);
        Task<object> GetAllUser();
        Task<object> GetUserById(Guid id);
        Task<object> DeleteUser(Guid id);
        Task<object> UpdateUser(Guid id, UpdateUserDto updateUserDto);
    }
}
