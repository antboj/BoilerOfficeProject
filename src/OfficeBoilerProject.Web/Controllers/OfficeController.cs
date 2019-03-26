using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfficeBoilerProject.OfficeAppService;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OfficeBoilerProject.Web.Controllers
{
    public class OfficeController : OfficeBoilerProjectControllerBase
    {
        private readonly IOfficeAppService _officeAppService;

        public OfficeController(IOfficeAppService officeAppService)
        {
            _officeAppService = officeAppService;
        }
        //GET: /<controller>/
        public IActionResult Office(string name)
        {
            var output = _officeAppService.GetOffice(name);
            return View(output);
        }
    }
}
