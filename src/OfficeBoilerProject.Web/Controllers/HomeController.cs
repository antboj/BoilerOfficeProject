using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace OfficeBoilerProject.Web.Controllers
{
    public class HomeController : OfficeBoilerProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Login()
        {
            return Challenge(new AuthenticationProperties
            {
                RedirectUri = "/Home/Index"
            }, "oidc");
        }

        public ActionResult Logout()
        {
            return SignOut(new AuthenticationProperties
            {
                RedirectUri = "Home/Index"
            }, "oidc", "Cookies");
        }
    }
}