using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OfficeBoilerProject.Models;

namespace OfficeBoilerProject.DeviceAppService.Dto
{
    [AutoMap(typeof(Device))]
    public class DeviceDtoPut : EntityDto
    {
        public string Name { get; set; }
        public int PersonId { get; set; }
    }
}
