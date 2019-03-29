using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OfficeBoilerProject.Models;

namespace OfficeBoilerProject.OfficeAppService.Dto
{
    [AutoMap(typeof(Office))]
    public class OfficeDto : EntityDto
    {
        public string Description { get; set; }
        public IList<Person> Persons { get; set; } = new List<Person>();

    }
}
