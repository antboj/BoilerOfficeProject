using Microsoft.EntityFrameworkCore;

namespace OfficeBoilerProject.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<OfficeBoilerProjectDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for OfficeBoilerProjectDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
