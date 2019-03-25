using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OfficeBoilerProject.Configuration;
using OfficeBoilerProject.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace OfficeBoilerProject.Web.Startup
{
    [DependsOn(
        typeof(OfficeBoilerProjectApplicationModule), 
        typeof(OfficeBoilerProjectEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class OfficeBoilerProjectWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public OfficeBoilerProjectWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(OfficeBoilerProjectConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<OfficeBoilerProjectNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(OfficeBoilerProjectApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OfficeBoilerProjectWebModule).GetAssembly());
        }
    }
}