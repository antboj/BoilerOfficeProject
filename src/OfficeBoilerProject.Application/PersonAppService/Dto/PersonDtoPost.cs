using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OfficeBoilerProject.Models;

namespace OfficeBoilerProject.PersonAppService.Dto
{
    [AutoMap(typeof(Person))]
    public class PersonDtoPost : EntityDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OfficeId { get; set; }
    }
}
