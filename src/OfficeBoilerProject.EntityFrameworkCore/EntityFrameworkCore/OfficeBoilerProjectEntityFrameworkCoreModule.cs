using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace OfficeBoilerProject.EntityFrameworkCore
{
    [DependsOn(
        typeof(OfficeBoilerProjectCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class OfficeBoilerProjectEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OfficeBoilerProjectEntityFrameworkCoreModule).GetAssembly());
        }
    }
}