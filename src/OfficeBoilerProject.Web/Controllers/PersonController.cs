using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfficeBoilerProject.PersonAppService;
using OfficeBoilerProject.PersonAppService.Dto;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OfficeBoilerProject.Web.Controllers
{
    public class PersonController : OfficeBoilerProjectControllerBase
    {
        private readonly IPersonAppService _personAppService;

        public PersonController(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }

        //GET: /<controller>/
        public IActionResult Index()
        {
            var output = _personAppService.Get();
            var model = new PersonViewModel(output.Items);
            return View(model);
        }

        public IActionResult Person(int id)
        {
            var output = _personAppService.GetById(id);
            return View(output);
        }
    }
}
