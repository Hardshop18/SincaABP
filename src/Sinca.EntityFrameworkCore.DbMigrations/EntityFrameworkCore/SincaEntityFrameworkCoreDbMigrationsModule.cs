using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Sinca.EntityFrameworkCore
{
    [DependsOn(
        typeof(SincaEntityFrameworkCoreModule)
        )]
    public class SincaEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<SincaMigrationsDbContext>();
        }
    }
}
