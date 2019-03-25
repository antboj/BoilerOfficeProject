using Abp.AspNetCore.Mvc.Views;

namespace OfficeBoilerProject.Web.Views
{
    public abstract class OfficeBoilerProjectRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected OfficeBoilerProjectRazorPage()
        {
            LocalizationSourceName = OfficeBoilerProjectConsts.LocalizationSourceName;
        }
    }
}
