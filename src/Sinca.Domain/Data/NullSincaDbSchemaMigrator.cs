using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Sinca.Data
{
    /* This is used if database provider does't define
     * ISincaDbSchemaMigrator implementation.
     */
    public class NullSincaDbSchemaMigrator : ISincaDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}