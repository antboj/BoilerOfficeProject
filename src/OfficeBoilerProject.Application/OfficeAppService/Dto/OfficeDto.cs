using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OfficeBoilerProject.Models;
using OfficeBoilerProject.PersonAppService.Dto;

namespace OfficeBoilerProject.OfficeAppService.Dto
{
    [AutoMap(typeof(Office))]
    public class OfficeDto : EntityDto
    {
        public string Description { get; set; }
        public List<PersonDto> Persons { get; set; } = new List<PersonDto>();

    }
}
