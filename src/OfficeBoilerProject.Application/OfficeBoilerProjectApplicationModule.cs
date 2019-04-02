using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OfficeBoilerProject.Models;
using OfficeBoilerProject.UsageAppService.Dto;

namespace OfficeBoilerProject
{
    [DependsOn(
        typeof(OfficeBoilerProjectCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class OfficeBoilerProjectApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                config.CreateMap<Usage, UsageDtoGet>()
                    .ForMember(d => d.Person, s => s.MapFrom(x => x.Person.FirstName + " " + x.Person.LastName))
                    .ForMember(d => d.Device, s => s.MapFrom(x => x.Device.Name));
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OfficeBoilerProjectApplicationModule).GetAssembly());
        }
    }
}