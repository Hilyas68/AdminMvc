using AdminMVC;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

[assembly: OwinStartup(typeof(StartUp))]
namespace AdminMVC
{
    public partial class StartUp
    {
            public static void Configuration(IAppBuilder app)
            {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ConfigureAuth(app);
            }
    }
}