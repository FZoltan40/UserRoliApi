using System.ComponentModel.DataAnnotations.Schema;

namespace UserRoleApi.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(45)")]
        public string Password { get; set; }
        public DateTime RegTime { get; set; } = DateTime.Now;

        //Kapcsolatok
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
