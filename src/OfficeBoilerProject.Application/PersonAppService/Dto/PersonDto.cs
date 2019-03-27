using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OfficeBoilerProject.Models;

namespace OfficeBoilerProject.PersonAppService.Dto
{
    [AutoMapFrom(typeof(Person))]
    public class PersonDto : EntityDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
