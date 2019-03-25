using System.Threading.Tasks;
using OfficeBoilerProject.Web.Controllers;
using Shouldly;
using Xunit;

namespace OfficeBoilerProject.Web.Tests.Controllers
{
    public class HomeController_Tests: OfficeBoilerProjectWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
