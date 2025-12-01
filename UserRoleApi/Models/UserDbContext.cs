using Microsoft.EntityFrameworkCore;

namespace UserRoleApi.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=authuser;user=root;password=");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasKey(ru => new { ru.UserId, ru.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ru => ru.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ru => ru.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ru => ru.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ru => ru.RoleId);
        }
    }

}

