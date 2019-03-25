using Abp.AspNetCore.Mvc.Controllers;

namespace OfficeBoilerProject.Web.Controllers
{
    public abstract class OfficeBoilerProjectControllerBase: AbpController
    {
        protected OfficeBoilerProjectControllerBase()
        {
            LocalizationSourceName = OfficeBoilerProjectConsts.LocalizationSourceName;
        }
    }
}