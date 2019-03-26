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
        OfficeDto GetOffice(string name);
        ListResultDto<OfficeDto> Get();
        OfficeDto GetById(int id);
        void Insert(OfficeDto input);
        void Update(int id, OfficeDto input);
        void Delete(int id);

    }
}
