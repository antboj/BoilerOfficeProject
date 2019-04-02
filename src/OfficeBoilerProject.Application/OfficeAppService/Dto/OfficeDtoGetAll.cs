using System.Collections.Generic;

namespace OfficeBoilerProject.OfficeAppService.Dto
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
