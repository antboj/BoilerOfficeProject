using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace OfficeBoilerProject.UsageAppService.Dto
{
    public class UsageByDeviceDtoGet
    {
        public List<UsageDtoGet> Usages { get; set; } = new List<UsageDtoGet>();
    }
}
