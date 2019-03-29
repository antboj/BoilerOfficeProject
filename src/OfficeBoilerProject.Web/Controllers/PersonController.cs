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
            var model = new PersonDtoGetAll(output.Items);
            return View(model);
        }

        public IActionResult Person(int? id)
        {
            PersonDto output = null;
            if (id.HasValue)
            {
                output = _personAppService.GetById(id.Value);
            }
            return View(output);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PersonDtoPost input)
        {
            _personAppService.Insert(input);
            return RedirectToAction("Index");
        }

        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _personAppService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(int id, PersonDtoPut input)
        {
            _personAppService.Update(id, input);
            return RedirectToAction("Index");
        }
    }
}
