using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.Application.Services;
using OfficeBoilerProject.Models;

namespace OfficeBoilerProject.UsageAppService
{
    public interface IUsageAppService : IApplicationService
    {
        void AddUsage(int dId, int pId);
        List<Usage> AllByDevice(int id);
        void EndUsing(int id);
    }
}
