using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Abp.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace OfficeBoilerProject.Web.Controllers
{
    public class HomeController : OfficeBoilerProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
        [AbpAuthorize]
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

        public async Task<IActionResult> Get()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:21021/api/services/app/DeviceType/GetDeviceTypes");
            var token = HttpContext.GetTokenAsync("access_token").Result;
            var client = new HttpClient();
            //request.Headers.Add("Authorization", token);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var jsoned = JsonConvert.DeserializeObject(content);
            return View(jsoned);
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