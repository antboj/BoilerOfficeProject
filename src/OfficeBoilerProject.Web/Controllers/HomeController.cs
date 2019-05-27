using System;
using System.Net.Http;
using System.Threading.Tasks;
using Abp.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace OfficeBoilerProject.Web.Controllers
{
    public class HomeController : OfficeBoilerProjectControllerBase
    {
        //private readonly HttpClient _client;

        //public HomeController(HttpClient client)
        //{
        //    _client = client;
        //}

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
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:21021/api/services/app/Device/GetDevices");
            var token = HttpContext.GetTokenAsync("id_token").Result;
            var client = new HttpClient();
            request.Headers.Add("Authorization", token);
            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            object jsoned;
            if (!response.IsSuccessStatusCode)
            {
                jsoned = JsonConvert.DeserializeObject(content);
                return View(jsoned);
            }
            jsoned = JsonConvert.DeserializeObject(content);
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