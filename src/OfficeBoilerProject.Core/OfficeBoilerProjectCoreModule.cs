using Abp.Modules;
using Abp.Reflection.Extensions;
using OfficeBoilerProject.Localization;

namespace OfficeBoilerProject
{
    public class OfficeBoilerProjectCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            OfficeBoilerProjectLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OfficeBoilerProjectCoreModule).GetAssembly());
        }
    }
}