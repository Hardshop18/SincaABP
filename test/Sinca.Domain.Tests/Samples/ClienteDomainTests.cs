using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Sinca.Samples
{
    /* This is just an example test class.
     * Normally, you don't test code of the modules you are using
     * (like IdentityUserManager here).
     * Only test your own domain services.
     */
    public class ClienteDomainTests : SincaDomainTestBase
    {

        public ClienteDomainTests()
        {

        }

        [Fact]
        public async Task Should_Cliente()
        {
            Cliente cliente = Cliente.Novo("teste");

            cliente.Nome.ShouldBe("teste");
        }
    }
}
