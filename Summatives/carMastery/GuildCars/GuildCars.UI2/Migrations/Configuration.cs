namespace GuildCars.UI2.Migrations
{
    using GuildCars.UI2.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GuildCars.UI2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GuildCars.UI2.Models.ApplicationDbContext context)
        {
            // Load the user and role managers with our custom models
            UserManager<ApplicationUser> userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            RoleManager<IdentityRole> roleMgr = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // have we loaded roles already?
            if (!roleMgr.RoleExists("admin"))
            {
                roleMgr.Create(new IdentityRole() { Name = "Admin" });
                roleMgr.Create(new IdentityRole() { Name = "Sales" });


            }


            // create the admin role

            // create the default user
            ApplicationUser user1 = new ApplicationUser
            {
                UserName = "Shadow",
                Email = "shadow@cars.com",
                FirstName = "Shadow",
                LastName = "Shadow"
            };

            ApplicationUser user2 = new ApplicationUser
            {
                UserName = "Mike",
                Email = "mike@cars.com",
                FirstName = "Mike",
                LastName = "Mike"
            };

            ApplicationUser user3 = new ApplicationUser
            {
                UserName = "Charlie",
                Email = "charlie@cars.com",
                FirstName = "Charlie",
                LastName = "Charlie"
            };

            ApplicationUser user4 = new ApplicationUser
            {
                UserName = "Leah",
                Email = "leah@cars.com",
                FirstName = "Leah",
                LastName = "Leah"
            };

            ApplicationUser user5 = new ApplicationUser
            {
                UserName = "Yen",
                Email = "yen@cars.com",
                FirstName = "yen",
                LastName = "yen"
            };

            // create the user with the manager class
            userMgr.Create(user1, "admin123");
            userMgr.Create(user2, "admin123");
            userMgr.Create(user3, "sales123");
            userMgr.Create(user4, "sales123");
            userMgr.Create(user5, "sales123");
            

            // add the user to the admin role
            userMgr.AddToRole(user1.Id, "Admin");
            userMgr.AddToRole(user2.Id, "Admin");
            userMgr.AddToRole(user3.Id, "Sales");
            userMgr.AddToRole(user4.Id, "Sales");
            userMgr.AddToRole(user5.Id, "Sales");

        }
    }
} 
