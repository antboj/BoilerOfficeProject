using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using OfficeBoilerProject.DeviceAppService.Dto;

namespace OfficeBoilerProject.DeviceAppService
{
    public class DeviceAppService : OfficeBoilerProjectAppServiceBase, IDeviceAppService
    {
        public ListResultDto<DeviceDto> Get()
        {
            throw new NotImplementedException();
        }

        public DeviceDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(DeviceDtoPost input)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, DeviceDtoPut input)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
