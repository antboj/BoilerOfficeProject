using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OfficeBoilerProject.DeviceAppService.Dto;
using OfficeBoilerProject.Models;
using OfficeBoilerProject.PersonAppService.Dto;

namespace OfficeBoilerProject.DeviceAppService
{
    public interface IDeviceAppService : IApplicationService
    {
        List<DeviceDto> Get();
        DeviceDto GetById(int id);
        int Insert(DeviceDtoPost input);
        void Update(int id, DeviceDtoPut input);
        void Delete(int id);
        Device GetDevice(int id);
        void ChangeUser(int pId, int dId);
    }
}
