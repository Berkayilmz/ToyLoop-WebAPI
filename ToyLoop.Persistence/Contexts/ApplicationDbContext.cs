
using Microsoft.EntityFrameworkCore;
using ToyLoop.Domain.Entities;

namespace ToyLoop.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasKey(u => u.UserId);
                entity.Property(u => u.Name).HasMaxLength(128);
                entity.Property(u => u.Surname).HasMaxLength(128);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(128);
                entity.Property(u => u.PasswordHash).IsRequired().HasMaxLength(255);
                entity.Property(u => u.Phone).IsRequired().HasMaxLength(20);

                //Relationships
                entity.HasOne(u => u.Location)
                    .WithMany(l => l.Users)
                    .HasForeignKey(u => u.LocationId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(u => u.Role)
                    .WithMany(r => r.Users)
                    .HasForeignKey(u => u.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("locations");

                entity.HasKey(l => l.LocationId);
                entity.Property(l => l.City).HasMaxLength(128);
                entity.Property(l => l.District).HasMaxLength(128);
                entity.Property(l => l.Slug).HasMaxLength(156);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.HasKey(r => r.RoleId);
                entity.Property(r => r.Name).IsRequired().HasMaxLength(50);
                entity.HasData(
                    new Role { RoleId = 1, Name = "User" },
                    new Role { RoleId = 2, Name = "Admin" }
                );
            });
        }
    }
}
