using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Sinca.Samples
{
    /* This is just an example test class.
     * Normally, you don't test code of the modules you are using
     * (like IIdentityUserAppService here).
     * Only test your own application services.
     */
    public class ClienteAppServiceTests : SincaApplicationTestBase
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteAppServiceTests()
        {
            _clienteAppService = GetRequiredService<IClienteAppService>();
        }

        [Fact]
        public async Task Initial_Data_Should_Contain_Cliente()
        {
            //Act
            var result = await _clienteAppService.GetListAsync(new GetClienteInput());

            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(u => u.Nome == "teste");
        }
    }
}
