using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OfficeBoilerProject.Models;
using OfficeBoilerProject.OfficeAppService.Dto;

namespace OfficeBoilerProject.OfficeAppService
{
    public class OfficeAppService : OfficeBoilerProjectAppServiceBase, IOfficeAppService
    {
        private readonly IRepository<Office> _officeRepository;

        public OfficeAppService(IRepository<Office> officeRepository)
        {
            _officeRepository = officeRepository;
        }


        public OfficeDto GetOffice(string name)
        {
            var office = _officeRepository.GetAll().Where(x => x.Description == name);
            if (office == null)
            {
                throw new Exception("Office Not Found");
            }
            return ObjectMapper.Map<OfficeDto>(office);
        }

        public ListResultDto<OfficeDto> Get()
        {
            var office = _officeRepository.GetAll().Include(p => p.Persons);
            return new ListResultDto<OfficeDto>(ObjectMapper.Map<List<OfficeDto>>(office));
        }

        public OfficeDto GetById(int id)
        {
            Office office;
            try
            {
                office = _officeRepository.Get(id);
            }
            catch (Exception)
            {
                throw new UserFriendlyException("ID Not Found");
            }
            return ObjectMapper.Map<OfficeDto>(office);
        }

        public void Insert(OfficeDto input)
        {
            var office = ObjectMapper.Map<Office>(input);
            _officeRepository.Insert(office);
        }

        public void Update(int id, OfficeDtoPut input)
        {
            _officeRepository.Update(id, ent =>
            {
                ObjectMapper.Map(input, ent);
            });
        }

        public void Delete(int id)
        {
            _officeRepository.Delete(id);
        }
    }
}
