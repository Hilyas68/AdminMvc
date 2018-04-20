using AdminMVC.Models;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AdminMVC.Controllers
{
    public class AuthController : Controller
    {
        public IAuthenticationManager Authentication
        {
            get
            {
                return this.Request.GetOwinContext().Authentication;
            }
        }

        //public AuthController()
        //{
        //}

        public ActionResult Logout()
        {
            Authentication.SignOut("ApplicationCookie");
            return Redirect("Login");
        }


        [HttpPost]
        public ActionResult Login(LoginInfo info)
        {
            string username = "htope68@gmail.com";
            string password = "admin";

            if (this.ModelState.IsValid)
            {
                if (username.Equals(info.Username) && password.Equals(info.Password))
                {
                    ClaimsIdentity claimsIdentity =
                        new ClaimsIdentity("ApplicationCookie");
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, info.Username));
                    //claimsIdentity.AddClaim(new Claim("PassportUrl", Url.Content("~/images/profile.png")));


                    var ctxt = this.Request.GetOwinContext();
                    ctxt.Authentication.SignIn(claimsIdentity);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    this.ModelState.AddModelError("", "Username or password is invalid");
                }
            }

            return View(info);
        }

        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginInfo();
            return View(model);
        }
    }

}
