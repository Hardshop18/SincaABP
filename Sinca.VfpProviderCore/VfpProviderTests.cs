using Xunit;
using VfpEntityFrameworkProvider;

namespace Sinca.VfpProviderCore
{
    public class VfpProviderTests
    {
        private readonly Context _context;

        public VfpProviderTests()
        {
            VfpProviderFactory.Register();
            string connectionString = @"D:\GitHub\dados\sinca.dbc"; //DELETED=true;data source=
            _context = new Context(new VfpConnection(connectionString));
        }

        [Fact]
        public void Procurar_VerificarSeNomeEIgual()
        {
            var teste = _context.TabelaTeste.Find(1);

            Assert.Equal(teste.nome, "Teste 1");
        }
    }
}
