using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace OfficeBoilerProject
{
    [DependsOn(
        typeof(OfficeBoilerProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class OfficeBoilerProjectApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OfficeBoilerProjectApplicationModule).GetAssembly());
            //iuioui
        }
    }
}