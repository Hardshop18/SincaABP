using Sinca.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Sinca.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(SincaEntityFrameworkCoreDbMigrationsModule),
        typeof(SincaApplicationContractsModule)
        )]
    public class SincaDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
