using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OfficeBoilerProject.DeviceAppService.Dto;
using OfficeBoilerProject.PersonAppService.Dto;

namespace OfficeBoilerProject.DeviceAppService
{
    public interface IDeviceAppService : IApplicationService
    {
        ListResultDto<DeviceDto> Get();
        DeviceDto GetById(int id);
        void Insert(DeviceDtoPost input);
        void Update(int id, DeviceDtoPut input);
        void Delete(int id);
    }
}
