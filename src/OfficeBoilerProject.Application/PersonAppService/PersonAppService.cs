using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using OfficeBoilerProject.Models;
using OfficeBoilerProject.PersonAppService.Dto;

namespace OfficeBoilerProject.PersonAppService
{
    public class PersonAppService : OfficeBoilerProjectAppServiceBase, IPersonAppService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonAppService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public ListResultDto<PersonDto> Get()
        {
            var person = _personRepository.GetAll();
            if (person == null)
            {
                throw new Exception("Office Not Found");
            }
            return new ListResultDto<PersonDto>(ObjectMapper.Map<List<PersonDto>>(person));
        }

        public PersonDto GetById(int id)
        {
            Person person;
            try
            {
                person = _personRepository.Get(id);
            }
            catch (Exception)
            {
                throw new Exception("ID Not Found");
            }
            return ObjectMapper.Map<PersonDto>(person);
        }

        public void Insert(PersonDtoPost input)
        {
            var office = ObjectMapper.Map<Person>(input);
            _personRepository.Insert(office);
        }

        public void Update(int id, PersonDtoPut input)
        {
            _personRepository.Update(id, ent =>
            {
                ObjectMapper.Map(input, ent);
            });
        }

        public void Delete(int id)
        {
            _personRepository.Delete(id);
        }
    }
}
