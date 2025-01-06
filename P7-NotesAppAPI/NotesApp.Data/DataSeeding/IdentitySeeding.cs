using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotesApp.Data.DataSeeding
{
    public static class IdentitySeeding
    {
        public static void GenerateData(ModelBuilder builder)
        {
            var adminRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin",
                NormalizedName = "ADMIN"
            };
            var userRole = new IdentityRole
            {
                Id = Guid.NewGuid().ToString(),
                Name = "User",
                NormalizedName = "USER"
            };
            builder.Entity<IdentityRole>().HasData(adminRole, userRole);

            // Seed Users
            var hasher = new PasswordHasher<IdentityUser>();
            var adminUser = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin@123"); // Contraseña: Admin@123
            var regularUser = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "user",
                NormalizedUserName = "USER",
                Email = "user@example.com",
                NormalizedEmail = "USER@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            regularUser.PasswordHash = hasher.HashPassword(regularUser, "User@123"); // Contraseña: User@123
            builder.Entity<IdentityUser>().HasData(adminUser, regularUser);

            // Assign Roles to Users
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = adminUser.Id,
                    RoleId = adminRole.Id
                },
                new IdentityUserRole<string>
                {
                    UserId = regularUser.Id,
                    RoleId = userRole.Id
                }
            );
        }
    }
}
