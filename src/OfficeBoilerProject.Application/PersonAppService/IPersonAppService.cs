using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OfficeBoilerProject.PersonAppService.Dto;

namespace OfficeBoilerProject.PersonAppService
{
    public interface IPersonAppService : IApplicationService
    {
        ListResultDto<PersonDto> Get();
        PersonDto GetById(int id);
        void Insert(PersonDto input);
        void Update(int id, PersonDto input);
        void Delete(int id);
    }
}
