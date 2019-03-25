using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OfficeBoilerProject.EntityFrameworkCore
{
    public class OfficeBoilerProjectDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public OfficeBoilerProjectDbContext(DbContextOptions<OfficeBoilerProjectDbContext> options) 
            : base(options)
        {

        }
    }
}
