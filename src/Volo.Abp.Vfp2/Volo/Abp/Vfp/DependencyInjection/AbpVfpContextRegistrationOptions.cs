using System;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.Vfp2.DependencyInjection
{
    public class AbpVfpContextRegistrationOptions : AbpCommonDbContextRegistrationOptions, IAbpVfpContextRegistrationOptionsBuilder
    {
        public AbpVfpContextRegistrationOptions(Type originalDbContextType, IServiceCollection services) 
            : base(originalDbContextType, services)
        {
        }
    }
}