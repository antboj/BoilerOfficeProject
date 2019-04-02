using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using OfficeBoilerProject.OfficeAppService;
using OfficeBoilerProject.OfficeAppService.Dto;

namespace OfficeBoilerProject.Web.Dto
{
    public class OfficeSelectListDto
    {
        public List<OfficeDto> Offices { get; set; }

        public OfficeSelectListDto(IOfficeAppService officeAppService)
        {
            Offices = officeAppService.Get().ToList();
        }
    }
}
