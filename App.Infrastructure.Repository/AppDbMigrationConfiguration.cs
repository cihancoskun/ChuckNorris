using System;
using System.Data.Entity.Migrations;
using System.Linq;

using App.Domain.Entities;
using App.Infrastructure.Helpers;

namespace App.Infrastructure.Repository
{
    public class AppDbMigrationConfiguration : DbMigrationsConfiguration<AppDbContext>
    {
        public AppDbMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AppDbContext context)
        {
            if (context.Users.Any()) return;

            AddAdmin(context, "Admin", "ADMÝN");
        }
          

        private static void AddAdmin(AppDbContext context, string name, string userName)
        {
            var user = new User
            {
                UserName = userName.ToLowerTR(),
                Name = name,
                RoleId = Roles.Admin.Value,
                RoleName = Roles.Admin.ToString(),
                ImageUrl = null,
                Password = "password",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("password"),
                LastLoginAt = DateTime.Now,
                IsActive = true
            };
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}