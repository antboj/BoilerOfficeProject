using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeBoilerProject.PersonAppService.Dto
{
    public class PersonViewModel
    {
        public IReadOnlyList<PersonDto> Persons { get; }

        public PersonViewModel(IReadOnlyList<PersonDto> persons)
        {
            Persons = persons;
        }
    }
}
