using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.TestApp.Vfp;
using Volo.Abp.Data;
using Volo.Abp.Autofac;
using Volo.Abp.TestApp2;
using Volo.Abp.TestApp2.Domain;

namespace Volo.Abp.Vfp
{
    [DependsOn(
        typeof(TestAppModule), 
        typeof(AbpVfpModule), 
        typeof(AbpAutofacModule))]
    public class AbpVfpTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = @"D:\GitHub\dados\SincaTeste.dbc"; 
            });

            context.Services.AddVfpContext<TestAppVfpContext>(options =>
            {
                options.AddDefaultRepositories();
                options.AddRepository<City, CityRepository>();
            });
        }
    }
}
