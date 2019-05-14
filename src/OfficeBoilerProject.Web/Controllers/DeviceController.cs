using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeBoilerProject.DeviceAppService;
using OfficeBoilerProject.DeviceAppService.Dto;
using OfficeBoilerProject.Models;
using OfficeBoilerProject.OfficeAppService.Dto;
using OfficeBoilerProject.PersonAppService;
using OfficeBoilerProject.UsageAppService;
using OfficeBoilerProject.UsageAppService.Dto;
using OfficeBoilerProject.Web.Dto;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OfficeBoilerProject.Web.Controllers
{
    public class DeviceController : OfficeBoilerProjectControllerBase
    {
        private readonly IDeviceAppService _deviceAppService;
        private readonly IPersonAppService _personAppService;
        private readonly IUsageAppService _usageAppService;

        public DeviceController(IDeviceAppService deviceAppService, IUsageAppService usageAppService, IPersonAppService personAppService)
        {
            _deviceAppService = deviceAppService;
            _usageAppService = usageAppService;
            _personAppService = personAppService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var allDevices = _deviceAppService.Get();
            var model = new DeviceDtoGetAll(allDevices);
            return View(model);
        }

        public IActionResult Device(int? id)
        {
            DeviceDto output = null;
            if (id.HasValue)
            {
                output = _deviceAppService.GetById(id.Value);
            }
            return View(output);
        }
        [Authorize]
        public IActionResult Add()
        {
            var persons = SelectPerson();
            ViewData["SelectPerson"] = persons;
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Add(DeviceDtoPost input)
        {
            var inserted = _deviceAppService.Insert(input);
            var deviceId = inserted;
            var personId = input.PersonId;
            _usageAppService.AddUsage(deviceId, personId);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Update(int id)
        {
            var device = _deviceAppService.GetDevice(id);
            DeviceDtoPut newDevice = new DeviceDtoPut
            {
                Name = device.Name,
                PersonId = device.PersonId
            };
            var persons = SelectPerson();
            ViewData["SelectPerson"] = persons;
            return View(newDevice);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Update(int id, DeviceDtoPut input)
        {
            _deviceAppService.ChangeUser(input.PersonId, id);
            _usageAppService.EndUsing(id);
            _usageAppService.AddUsage(id, input.PersonId);
            _deviceAppService.Update(id, input);
            return RedirectToAction("Index");
        }

        [AbpAuthorize("delApi")]
        public IActionResult Delete(int? id)
        {
            DeviceDto output = null;
            if (id.HasValue)
            {
                output = _deviceAppService.GetById(id.Value);
            }
            return View(output);
        }

        [AbpAuthorize("delApi")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _deviceAppService.Delete(id);
            return RedirectToAction("Index");
        }

        public SelectList SelectPerson()
        {
            var person = new PersonSelectListDto(_personAppService);

            var persons = person.Persons.ToList();

            var selectPerson = persons.Select(x => new
            {
                Id = x.Id,
                Name = x.FirstName + " " + x.LastName
            });

            SelectList selectPersons = new SelectList(selectPerson, "Id", "Name");

            return selectPersons;
        }

        public IActionResult History(int id)
        {
            var usage = _usageAppService.AllByDevice(id);
            ViewData["UsageList"] = usage;
            UsageByDeviceDtoGet list = new UsageByDeviceDtoGet();
            list.Usages = ObjectMapper.Map<List<UsageDtoGet>>(usage);
            return View(list);
        }
    }
}
