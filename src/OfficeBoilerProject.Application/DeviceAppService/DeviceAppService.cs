using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using OfficeBoilerProject.DeviceAppService.Dto;
using OfficeBoilerProject.Models;

namespace OfficeBoilerProject.DeviceAppService
{
    public class DeviceAppService : OfficeBoilerProjectAppServiceBase, IDeviceAppService
    {
        private readonly IRepository<Device> _deviceRepository;

        public DeviceAppService(IRepository<Device> deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public ListResultDto<DeviceDto> Get()
        {
            var allDevices = _deviceRepository.GetAll();
            return new ListResultDto<DeviceDto>(ObjectMapper.Map<List<DeviceDto>>(allDevices));
        }

        public DeviceDto GetById(int id)
        {
            Device device;
            try
            {
                device = _deviceRepository.Get(id);
            }
            catch (Exception)
            {
                throw new Exception("ID Not Found");
            }
            return ObjectMapper.Map<DeviceDto>(device);
        }

        public int Insert(DeviceDtoPost input)
        {
            var device = ObjectMapper.Map<Device>(input);
            var inserted = _deviceRepository.InsertAndGetId(device);
            return inserted;
        }

        public void Update(int id, DeviceDtoPut input)
        {
            _deviceRepository.Update(id, ent =>
            {
                ObjectMapper.Map(input, ent);
            });
        }

        public void Delete(int id)
        {
            _deviceRepository.Delete(id);
        }

        public Device GetDevice(int id)
        {
            var all = _deviceRepository.GetAll().Include(p => p.Person);
            var device = all.FirstOrDefault(x => x.Id == id);

            if (device == null)
            {
                throw new Exception("ID Not Found");
            }
            return device;
        }

        public void ChangeUser(int pId, int dId)
        {
            var foundDevice = _deviceRepository.Get(dId);

            if (foundDevice == null)
            {
                throw new Exception("Uredjaj ne postoji");
            }

            if (foundDevice.PersonId == pId && foundDevice.Id == dId)
            {
                throw new Exception("Korisnik vec koristi trazeni uredjaj");
            }

            foundDevice.PersonId = pId;
        }
    }
}
