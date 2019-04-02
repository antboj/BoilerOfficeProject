using System;
using Abp.Application.Services.Dto;

namespace OfficeBoilerProject.UsageAppService.Dto
{
    public class UsageDtoGet : EntityDto
    {
        public string Person { get; set; }
        public string Device { get; set; }
        public DateTime UsedFrom { get; set; }
        public DateTime? UsedTo { get; set; }
    }
}
