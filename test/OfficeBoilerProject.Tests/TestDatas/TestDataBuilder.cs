using OfficeBoilerProject.EntityFrameworkCore;

namespace OfficeBoilerProject.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly OfficeBoilerProjectDbContext _context;

        public TestDataBuilder(OfficeBoilerProjectDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}