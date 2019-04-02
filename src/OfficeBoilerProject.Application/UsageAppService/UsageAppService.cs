using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using OfficeBoilerProject.Models;

namespace OfficeBoilerProject.UsageAppService
{
    public class UsageAppService : OfficeBoilerProjectAppServiceBase, IUsageAppService
    {
        private readonly IRepository<Usage> _usageRepository;

        public UsageAppService(IRepository<Usage> usageRepository)
        {
            _usageRepository = usageRepository;
        }

        public void AddUsage(int dId, int pId)
        {
            var usage = new Usage
            {
                PersonId = pId,
                DeviceId = dId,
                UsedFrom = DateTime.Now
            };

            _usageRepository.Insert(usage);
        }

        public List<Usage> AllByDevice(int id)
        {
            var all =  _usageRepository.GetAll().Include(p => p.Person).Include(d => d.Device);
            var found = all.Where(x => x.DeviceId == id).ToList();
            return found;
        }

        public void EndUsing(int id)
        {
            var usageRecord = _usageRepository.FirstOrDefault(u => u.DeviceId == id && u.UsedTo == null);

            if (usageRecord != null)
            {
                usageRecord.UsedTo = DateTime.Now;
            }
        }
    }
}
