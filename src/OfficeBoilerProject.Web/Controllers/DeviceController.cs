using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OfficeBoilerProject.DeviceAppService;
using OfficeBoilerProject.DeviceAppService.Dto;
using OfficeBoilerProject.Models;
using OfficeBoilerProject.OfficeAppService.Dto;
using OfficeBoilerProject.UsageAppService;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OfficeBoilerProject.Web.Controllers
{
    public class DeviceController : OfficeBoilerProjectControllerBase
    {
        private readonly IDeviceAppService _deviceAppService;
        private readonly IUsageAppService _usageAppService;

        public DeviceController(IDeviceAppService deviceAppService, IUsageAppService usageAppService)
        {
            _deviceAppService = deviceAppService;
            _usageAppService = usageAppService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var allDevices = _deviceAppService.Get();
            var model = new DeviceDtoGetAll(allDevices.Items);
            return View(model);
        }

        public IActionResult Device(int? id)
        {
            Device output = null;
            if (id.HasValue)
            {
                output = _deviceAppService.GetDevice(id.Value);
            }
            return View(output);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(DeviceDtoPost input)
        {
            var inserted = _deviceAppService.Insert(input);
            var deviceId = inserted;
            var personId = input.PersonId;
            _usageAppService.AddUsage(deviceId, personId);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var device = _deviceAppService.GetDevice(id);
            DeviceDtoPut newDevice = new DeviceDtoPut
            {
                Name = device.Name,
                PersonId = (int) device.PersonId
            };
            return View(newDevice);
        }

        [HttpPost]
        public IActionResult Update(int id, DeviceDtoPut input)
        {
            _deviceAppService.ChangeUser(input.PersonId, id);
            _usageAppService.EndUsing(id);
            _usageAppService.AddUsage(id, input.PersonId);
            _deviceAppService.Update(id, input);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            DeviceDto output = null;
            if (id.HasValue)
            {
                output = _deviceAppService.GetById(id.Value);
            }
            return View(output);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _deviceAppService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
