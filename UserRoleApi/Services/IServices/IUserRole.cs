using UserRoleApi.Models.Dtos;

namespace UserRoleApi.Services.IServices
{
    public interface IUserRole
    {
        Task<object> AddNewConnection(AddUserRoleDto addUserRoleDto);
    }
}
