using OfficeBoilerProject.Configuration;
using OfficeBoilerProject.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace OfficeBoilerProject.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class OfficeBoilerProjectDbContextFactory : IDesignTimeDbContextFactory<OfficeBoilerProjectDbContext>
    {
        public OfficeBoilerProjectDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<OfficeBoilerProjectDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(OfficeBoilerProjectConsts.ConnectionStringName)
            );

            return new OfficeBoilerProjectDbContext(builder.Options);
        }
    }
}