using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OfficeBoilerProject.Models;

namespace OfficeBoilerProject.EntityFrameworkCore
{
    public class OfficeBoilerProjectDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...
        public DbSet<Office> Offices { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Device> Devices { get; set; }

        public OfficeBoilerProjectDbContext(DbContextOptions<OfficeBoilerProjectDbContext> options) 
            : base(options)
        {

        }
    }
}
