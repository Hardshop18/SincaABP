using System;
using Microsoft.Extensions.DependencyInjection;
using Mongo2Go;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.TestApp;
using Volo.Abp.TestApp.Domain;
using Volo.Abp.TestApp.Vfp2;

namespace Volo.Abp.Vfp2
{
    [DependsOn(
        typeof(AbpVfpModule),
        typeof(TestAppModule)
        )]
    public class AbpVfpTestModule : AbpModule
    {
        private static readonly MongoDbRunner MongoDbRunner = MongoDbRunner.Start();

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var connectionString = MongoDbRunner.ConnectionString.EnsureEndsWith('/') +
                                   "Db_" +
                                    Guid.NewGuid().ToString("N");

            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = connectionString;
            });

            context.Services.AddVfpContext<TestAppVfpContext>(options =>
            {
                options.AddDefaultRepositories<ITestAppVfpContext>();
                options.AddRepository<City, CityRepository>();
            });
        }
    }
}
