using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficeBoilerProject.PersonAppService;
using OfficeBoilerProject.PersonAppService.Dto;

namespace OfficeBoilerProject.Web.Dto
{
    public class PersonSelectListDto
    {
        public List<PersonDto> Persons { get; set; }

        public PersonSelectListDto(IPersonAppService personAppService)
        {
            Persons = personAppService.Get().ToList();
        }
    }
}
