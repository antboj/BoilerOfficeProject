using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfficeBoilerProject.OfficeAppService.Dto;

namespace OfficeBoilerProject.Web.Views
{
    public class OfficeDtoGetAll
    {
        public IReadOnlyList<OfficeDto> Offices { get; }

        public OfficeDtoGetAll(IReadOnlyList<OfficeDto> offices)
        {
            Offices = offices;
        }
    }
}
