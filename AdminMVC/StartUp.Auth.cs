using AdminMVC.DataAccess;
using AdminMVC.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

namespace AdminMVC
{
    public partial class StartUp
    {
        public static Func<UserManager<AppUser, int>> UserManagerFactory { get; private set; } = Create;

        public static Func<RoleManager<AppRole, int>> UserRoleFactory { get; private set; } = CreateRole;
        public static void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            var option = new CookieAuthenticationOptions()
            {
                AuthenticationType = "ApplicationCookie",
                CookieName = "Admin",
                LoginPath = new PathString("/Auth/Login")
            };
            app.UseCookieAuthentication(option);

            app.UseGoogleAuthentication(
        clientId: "943878812622-3esrgkg1puv20cof6fjb1ki2avg0olca.apps.googleusercontent.com",
        clientSecret: "4500pxs_te6vnibut43bugc6");
        }

        public static UserManager<AppUser, int> Create()
        {
            var dbContext = new AdminDBContext();
            var store = new UserStore<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>(dbContext);
            var usermanager = new UserManager<AppUser, int>(store);
            // allow alphanumeric characters in username
            usermanager.UserValidator = new UserValidator<AppUser, int>(usermanager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false,
            };

            usermanager.PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 4,
                RequireDigit = false,
                RequireUppercase = false
            };

            return usermanager;
        }

        public static RoleManager<AppRole, int> CreateRole()
        {
            var dbContext = new AdminDBContext();
            var store = new RoleStore<AppRole, int, AppUserRole>(dbContext);
            var rolemanager = new RoleManager<AppRole, int>(store);

            return rolemanager;
        }
    }
}