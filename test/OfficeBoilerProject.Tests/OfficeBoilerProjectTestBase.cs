using System;
using System.Threading.Tasks;
using Abp.TestBase;
using OfficeBoilerProject.EntityFrameworkCore;
using OfficeBoilerProject.Tests.TestDatas;

namespace OfficeBoilerProject.Tests
{
    public class OfficeBoilerProjectTestBase : AbpIntegratedTestBase<OfficeBoilerProjectTestModule>
    {
        public OfficeBoilerProjectTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<OfficeBoilerProjectDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<OfficeBoilerProjectDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<OfficeBoilerProjectDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<OfficeBoilerProjectDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<OfficeBoilerProjectDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<OfficeBoilerProjectDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<OfficeBoilerProjectDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<OfficeBoilerProjectDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
