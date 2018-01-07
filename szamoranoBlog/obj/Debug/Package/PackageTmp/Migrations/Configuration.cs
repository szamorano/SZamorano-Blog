namespace szamoranoBlog.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using szamoranoBlog.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<szamoranoBlog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(szamoranoBlog.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }
            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            if (!context.Users.Any(u => u.Email == "steven.zamorano@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "steven.zamorano@gmail.com",
                    Email = "steven.zamorano@gmail.com",
                    FirstName = "Steven",
                    LastName = "Zamorano",
                }, "Password1!");
            }
            var userId = userManager.FindByEmail("steven.zamorano@gmail.com").Id;
            userManager.AddToRole(userId, "Admin");
            if (!context.Users.Any(u => u.Email == "rchapman@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "rchapman@coderfoundry.com",
                    Email = "rchapman@coderfoundry.com",
                    FirstName = "Ryan",
                    LastName = "Chapman",
                }, "Password1!");
            }
            var userId_ryan = userManager.FindByEmail("rchapman@coderfoundry.com").Id;
            userManager.AddToRole(userId_ryan, "Moderator");
            if (!context.Users.Any(u => u.Email == "mjaang@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "mjaang@coderfoundry.com",
                    Email = "mjaang@coderfoundry.com",
                    FirstName = "Mark",
                    LastName = "Jaang",
                }, "Password1!");
            }
            var userId_mark = userManager.FindByEmail("mjaang@coderfoundry.com").Id;
            userManager.AddToRole(userId_mark, "Moderator");
        }
    }
}
