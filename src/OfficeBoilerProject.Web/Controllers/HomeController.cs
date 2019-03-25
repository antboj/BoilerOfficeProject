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
    }
}