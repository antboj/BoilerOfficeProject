using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeBoilerProject.Models;
using OfficeBoilerProject.OfficeAppService;
using OfficeBoilerProject.PersonAppService;
using OfficeBoilerProject.PersonAppService.Dto;
using OfficeBoilerProject.Web.Dto;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OfficeBoilerProject.Web.Controllers
{
    public class PersonController : OfficeBoilerProjectControllerBase
    {
        private readonly IPersonAppService _personAppService;
        private readonly IOfficeAppService _officeAppService;

        public PersonController(IPersonAppService personAppService, IOfficeAppService officeAppService)
        {
            _personAppService = personAppService;
            _officeAppService = officeAppService;
        }

        //GET: /<controller>/
        public IActionResult Index()
        {
            var output = _personAppService.Get();
            var model = new PersonDtoGetAll(output);
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

        [Authorize]
        public IActionResult Add()
        {
            var offices = SelectOffice();
            ViewData["OfficeList"] = offices;
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(PersonDtoPost input)
        {
            _personAppService.Insert(input);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            PersonDto output = null;
            if (id.HasValue)
            {
                output = _personAppService.GetById(id.Value);
            }
            return View(output);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _personAppService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var person = _personAppService.GetPerson(id);
            PersonDtoPut newPerson = new PersonDtoPut
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                OfficeId = person.OfficeId
            };
            var offices = SelectOffice();
            ViewData["OfficeList"] = offices;
            return View(newPerson);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(int id, PersonDtoPut input)
        {
            _personAppService.Update(id, input);
            return RedirectToAction("Index");
        }

        public SelectList SelectOffice()
        {
            var office = new OfficeSelectListDto(_officeAppService);

            var offices = office.Offices.ToList();

            SelectList selectOffices = new SelectList(offices, "Id", "Description");

            return selectOffices;
        }
    }
}
