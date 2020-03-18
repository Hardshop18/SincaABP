using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Sinca
{
    public class SincaTestDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Cliente, Guid> _clienteRepository;
        private readonly IGuidGenerator _guidGenerator;

        public SincaTestDataSeedContributor(
            IRepository<Cliente, Guid> clienteRepository,
            IGuidGenerator guidGenerator)
        {
            _clienteRepository = clienteRepository;
            _guidGenerator = guidGenerator;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            /* Seed additional test data... */
            await _clienteRepository.InsertAsync(new Cliente() { Nome = "teste", Observacao = "teste" });
        }
    }
}