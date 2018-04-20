using System.Web.Mvc;

namespace AdminMVC.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}