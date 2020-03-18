using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Sinca.Pages
{
    public class Index_Tests : SincaWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
