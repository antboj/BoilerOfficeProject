using System.Reflection;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.TestBase;
using OfficeBoilerProject.EntityFrameworkCore;
using Castle.MicroKernel.Registration;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OfficeBoilerProject.Tests
{
    [DependsOn(
        typeof(OfficeBoilerProjectApplicationModule),
        typeof(OfficeBoilerProjectEntityFrameworkCoreModule),
        typeof(AbpTestBaseModule)
        )]
    public class OfficeBoilerProjectTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
            SetupInMemoryDb();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(OfficeBoilerProjectTestModule).GetAssembly());
        }

        private void SetupInMemoryDb()
        {
            var services = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase();

            var serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(
                IocManager.IocContainer,
                services
            );

            var builder = new DbContextOptionsBuilder<OfficeBoilerProjectDbContext>();
            builder.UseInMemoryDatabase().UseInternalServiceProvider(serviceProvider);

            IocManager.IocContainer.Register(
                Component
                    .For<DbContextOptions<OfficeBoilerProjectDbContext>>()
                    .Instance(builder.Options)
                    .LifestyleSingleton()
            );
        }
    }
}