using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfficeBoilerProject.OfficeAppService;
using OfficeBoilerProject.OfficeAppService.Dto;
using OfficeBoilerProject.Web.Views;

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

        public IActionResult Index()
        {
            var output = _officeAppService.Get();
            var model = new OfficeViewModel(output.Items);
            return View(model);
        }

        public IActionResult Office(int id)
        {
            var output = _officeAppService.GetById(id);
            return View(output);
        }

        public IActionResult Name(string name)
        {
            var output = _officeAppService.GetOffice();
            var model = new OfficeViewModel(output.Items);
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(OfficeDto input)
        {
            _officeAppService.Insert(input);
            return RedirectToAction("Index");
        }
    }
}
