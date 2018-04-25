using System.Web.Mvc;

namespace AdminMVC.App_Start
{
    public class FilterConfig
    {
        public static void Configure(GlobalFilterCollection filter)
        {
            filter.Add(new AuthorizeAttribute());
        }
    }
}