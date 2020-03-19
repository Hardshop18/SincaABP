using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.Vfp.DependencyInjection
{
    public class AbpVfpContextRegistrationOptions : AbpCommonDbContextRegistrationOptions, IAbpVfpContextRegistrationOptionsBuilder
    {
        public AbpVfpContextRegistrationOptions(Type originalDbContextType, IServiceCollection services) 
            : base(originalDbContextType, services)
        {
        }
    }
}