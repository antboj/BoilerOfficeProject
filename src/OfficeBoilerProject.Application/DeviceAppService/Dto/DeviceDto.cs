using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OfficeBoilerProject.Models;

namespace OfficeBoilerProject.DeviceAppService
{
    [AutoMap(typeof(Device))]
    public class DeviceDto : EntityDto
    {
        public string Name { get; set; }
    }
}
