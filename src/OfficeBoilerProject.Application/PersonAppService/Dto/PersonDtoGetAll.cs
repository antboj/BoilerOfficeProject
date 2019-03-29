using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeBoilerProject.PersonAppService.Dto
{
    public class PersonDtoGetAll
    {
        public IReadOnlyList<PersonDto> Persons { get; }

        public PersonDtoGetAll(IReadOnlyList<PersonDto> persons)
        {
            Persons = persons;
        }
    }
}
