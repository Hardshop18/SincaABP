using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Uow;

namespace Sinca.IdentityServer
{
    public class IdentityServerDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly IPermissionDataSeeder _permissionDataSeeder;
        private readonly IConfiguration _configuration;

        public IdentityServerDataSeedContributor(
            IGuidGenerator guidGenerator,
            IPermissionDataSeeder permissionDataSeeder,
            IConfiguration configuration)
        {
            _guidGenerator = guidGenerator;
            _permissionDataSeeder = permissionDataSeeder;
            _configuration = configuration;
        }

        [UnitOfWork]
        public virtual async Task SeedAsync(DataSeedContext context)
        {
        }
    }
}
