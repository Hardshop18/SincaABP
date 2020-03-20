using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.Vfp2;
using Volo.Abp.Vfp2.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AbpVfpServiceCollectionExtensions
    {
        public static IServiceCollection AddVfpContext<TVfpContext>(this IServiceCollection services, Action<IAbpVfpContextRegistrationOptionsBuilder> optionsBuilder = null) //Created overload instead of default parameter
            where TVfpContext : AbpVfpContext
        {
            var options = new AbpMongoDbContextRegistrationOptions(typeof(TVfpContext), services);
            optionsBuilder?.Invoke(options);

            foreach (var dbContextType in options.ReplacedDbContextTypes)
            {
                services.Replace(ServiceDescriptor.Transient(dbContextType, typeof(TVfpContext)));
            }

            new VfpRepositoryRegistrar(options).AddRepositories();

            return services;
        }
    }
}
