using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OfficeBoilerProject.Models;
using OfficeBoilerProject.OfficeAppService.Dto;

namespace OfficeBoilerProject.OfficeAppService
{
    public interface IOfficeAppService : IApplicationService
    {
        
        List<OfficeDto> Get();
        OfficeDto GetById(int id);
        OfficeDtoGet GetOffice(int id);
        void Insert(OfficeDto input);
        void Update(int id, OfficeDtoPut input);
        void Delete(int id);

    }
}
