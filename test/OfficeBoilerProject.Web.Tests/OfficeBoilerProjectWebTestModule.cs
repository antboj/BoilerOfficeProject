using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using OfficeBoilerProject.Web.Startup;
namespace OfficeBoilerProject.Web.Tests
{
    [DependsOn(
        typeof(OfficeBoilerProjectWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class OfficeBoilerProjectWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OfficeBoilerProjectWebTestModule).GetAssembly());
        }
    }
}