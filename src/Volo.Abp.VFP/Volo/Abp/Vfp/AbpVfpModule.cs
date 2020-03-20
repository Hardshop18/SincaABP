using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.Domain;
using Volo.Abp.Domain.Repositories.Vfp;
using Volo.Abp.Json;
using Volo.Abp.Modularity;
using Volo.Abp.Uow.Vfp;

namespace Volo.Abp.Vfp
{
    [DependsOn(typeof(AbpDddDomainModule))]
    public class AbpVfpModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.TryAddTransient(typeof(IVfpProvider<>), typeof(UnitOfWorkVfpProvider<>));
            context.Services.TryAddTransient(typeof(IVfpCollection<>), typeof(VfpCollection<>));
        }
    }
}
