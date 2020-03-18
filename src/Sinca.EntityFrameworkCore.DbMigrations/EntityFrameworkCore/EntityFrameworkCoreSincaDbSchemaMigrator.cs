using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sinca.Data;
using Volo.Abp.DependencyInjection;

namespace Sinca.EntityFrameworkCore
{
    [Dependency(ReplaceServices = true)]
    public class EntityFrameworkCoreSincaDbSchemaMigrator 
        : ISincaDbSchemaMigrator, ITransientDependency
    {
        private readonly SincaMigrationsDbContext _dbContext;

        public EntityFrameworkCoreSincaDbSchemaMigrator(SincaMigrationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task MigrateAsync()
        {
            await _dbContext.Database.MigrateAsync();
        }
    }
}