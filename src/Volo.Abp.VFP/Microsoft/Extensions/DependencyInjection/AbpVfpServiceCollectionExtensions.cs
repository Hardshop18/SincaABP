using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.Vfp;
using Volo.Abp.Vfp.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AbpVfpServiceCollectionExtensions
    {
        public static IServiceCollection AddVfpContext<TVfpContext>(this IServiceCollection services, Action<IAbpVfpContextRegistrationOptionsBuilder> optionsBuilder = null)
            where TVfpContext : VfpContext
        {
            var options = new AbpVfpContextRegistrationOptions(typeof(TVfpContext), services);
            optionsBuilder?.Invoke(options);

            if (options.DefaultRepositoryDbContextType != typeof(TVfpContext))
            {
                services.TryAddSingleton(options.DefaultRepositoryDbContextType, sp => sp.GetRequiredService<TVfpContext>());
            }

            foreach (var dbContextType in options.ReplacedDbContextTypes)
            {
                services.Replace(ServiceDescriptor.Singleton(dbContextType, sp => sp.GetRequiredService<TVfpContext>()));
            }

            new VfpRepositoryRegistrar(options).AddRepositories();

            return services;
        }
    }
}
