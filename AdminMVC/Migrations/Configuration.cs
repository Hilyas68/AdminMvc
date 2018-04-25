namespace AdminMVC.Migrations
{
    using AdminMVC.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AdminMVC.DataAccess.AdminDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AdminMVC.DataAccess.AdminDBContext context)
        {

            string username = "admin@cyberspace.com";
            string password = "admin";
            string role = "ADMIN";

            var userMgr = StartUp.UserManagerFactory.Invoke();
            var userRole = StartUp.UserRoleFactory.Invoke();


            if (userMgr.FindByName(username) != null)
                return;

            var appUser = new AppUser()
            {
                UserName = username,
                CreatedOn = DateTime.Now

            };

            var result = userMgr.Create<AppUser, int>(appUser, password);

            if (!userRole.RoleExists(role))
            {
                var irole = new AppRole() { Name = role };
                userRole.Create<AppRole, int>(irole);
            }

            if (!userMgr.IsInRole<AppUser, int>(appUser.Id, role))
            {
                userMgr.AddToRole<AppUser, int>(appUser.Id, role);
            }


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
