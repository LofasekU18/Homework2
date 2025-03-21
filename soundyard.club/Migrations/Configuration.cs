namespace soundyard.club.Migrations
{
    using global::club.soundyard.web.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Diagnostics;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roles = new[]
        {
            new { Name = "Admin", Agreement = "Full access to the system" },
            new { Name = "User", Agreement = "Can access general features" },
            new { Name = "Manager", Agreement = "Manages users and content" }
        };

            foreach (var role in roles)
            {
                if (!context.Roles.Any(r => r.Name == role.Name))
                {
                    var newRole = new ApplicationRole(role.Name, role.Agreement);
                    roleManager.Create(newRole);
                }
            }
        }
    }
}
