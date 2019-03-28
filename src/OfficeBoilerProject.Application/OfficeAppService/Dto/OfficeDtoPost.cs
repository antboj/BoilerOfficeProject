using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeBoilerProject.OfficeAppService.Dto
{
    public class OfficeDtoPost
    {
        public OfficeDto Office { get; set; }

        public OfficeDtoPost( OfficeDto office)
        {
            Office = office;
        }
    }
}
