using AdminMVC;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(StartUp))]
namespace AdminMVC
{
    public partial class StartUp
    {
        public static void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}