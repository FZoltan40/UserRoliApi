namespace UserRoleApi.Models.Dtos
{
    public class AddUserRoleDto
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
