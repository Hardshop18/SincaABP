using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.Uow.Vfp2;

namespace Volo.Abp.Vfp2
{
    [DependsOn(typeof(AbpDddDomainModule))]
    public class AbpVfpDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.TryAddTransient(
                typeof(IVfpContextProvider<>),
                typeof(UnitOfWorkVfpContextProvider<>)
            );
        }
    }
}
