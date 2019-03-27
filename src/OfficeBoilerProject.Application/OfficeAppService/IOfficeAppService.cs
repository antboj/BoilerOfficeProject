using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OfficeBoilerProject.OfficeAppService.Dto;

namespace OfficeBoilerProject.OfficeAppService
{
    public interface IOfficeAppService : IApplicationService
    {
        
        ListResultDto<OfficeDto> Get();
        OfficeDto GetById(int id);
        ListResultDto<OfficeDto> GetOffice();
        void Insert(OfficeDto input);
        void Update(int id, OfficeDto input);
        void Delete(int id);

    }
}
