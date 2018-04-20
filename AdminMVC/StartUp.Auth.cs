using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace AdminMVC
{
    public partial class StartUp
    {
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

    }
}