using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
            var model = new OfficeDtoGetAll(output);
            return View(model);
        }
        [HttpGet]
        public IActionResult Office(int? id)
        {
            OfficeDtoGet output = null;
            if (id.HasValue)
            {
                output = _officeAppService.GetOffice(id.Value);
            }
            return View(output);
        }

        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(OfficeDto input)
        {
            _officeAppService.Insert(input);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            OfficeDto output = null;
            if (id.HasValue)
            {
                output = _officeAppService.GetById(id.Value);
            }
            return View(output);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            _officeAppService.Delete(id);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Update(int id)
        {
            var office = _officeAppService.GetOffice(id);
            OfficeDtoPut newOffice = new OfficeDtoPut
            {
                Description = office.Description
            };
            return View(newOffice);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(int id, OfficeDtoPut input)
        {
            _officeAppService.Update(id, input);
            return RedirectToAction("Index");
        }
    }
}
