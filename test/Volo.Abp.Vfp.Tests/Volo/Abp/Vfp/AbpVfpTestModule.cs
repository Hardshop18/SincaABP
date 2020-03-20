﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.TestApp.Vfp;
using Volo.Abp.Data;
using Volo.Abp.Autofac;
using Volo.Abp.TestApp;
using Volo.Abp.TestApp.Domain;

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
            var connStr = Guid.NewGuid().ToString();

            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = connStr;
            });

            context.Services.AddVfpContext<TestAppVfpContext>(options =>
            {
                options.AddDefaultRepositories();
                options.AddRepository<City, CityRepository>();
            });
        }
    }
}