using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Sinca.EntityFrameworkCore.Samples
{
    public class ClienteRepositoryTests : SincaEntityFrameworkCoreTestBase
    {
        private readonly IRepository<Cliente, Guid> _clienteRepository;

        public ClienteRepositoryTests()
        {
            _clienteRepository = GetRequiredService<IRepository<Cliente, Guid>>();
        }

        [Fact]
        public async Task Should_Query_Cliente()
        {
            /* Need to manually start Unit Of Work because
             * FirstOrDefaultAsync should be executed while db connection / context is available.
             */

            await WithUnitOfWorkAsync(async () =>
            {
                Cliente novoCliente = Cliente.Novo("teste");
                var novo = await _clienteRepository.InsertAsync(novoCliente, true);

                //Act
                var cliente = await _clienteRepository
                    .Where(u => u.Nome == "teste")
                    .FirstOrDefaultAsync();

                //Assert
                cliente.ShouldNotBeNull();
            });
        }
    }
}
