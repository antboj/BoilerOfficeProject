using Abp.Application.Services;

namespace OfficeBoilerProject
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class OfficeBoilerProjectAppServiceBase : ApplicationService
    {
        protected OfficeBoilerProjectAppServiceBase()
        {
            LocalizationSourceName = OfficeBoilerProjectConsts.LocalizationSourceName;
        }
    }
}