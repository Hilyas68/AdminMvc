using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminMVC
{
	public partial class StartUp
	{
        public static void ConfigureAuth(IAppBuilder app)
        {
            var option = new CookieAuthenticationOptions()
            {
				AuthenticationType = "ApplicationCookie",
                CookieName = "Admin",
                LoginPath = new PathString("/Auth/Login")
            };
            app.UseCookieAuthentication(option);
        }
    }
}