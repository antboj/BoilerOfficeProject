using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using OfficeBoilerProject.Models;
using OfficeBoilerProject.PersonAppService.Dto;

namespace OfficeBoilerProject.PersonAppService
{
    public interface IPersonAppService : IApplicationService
    {
        List<PersonDto> Get();
        PersonDto GetById(int id);
        Person GetPerson(int id);
        void Insert(PersonDtoPost input);
        void Update(int id, PersonDtoPut input);
        void Delete(int id);
    }
}
