using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.Vfp;
using Volo.Abp.Vfp.DependencyInjection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AbpVfpServiceCollectionExtensions
    {
        public static IServiceCollection AddVfpContext<TMemoryDbContext>(this IServiceCollection services, Action<IAbpVfpContextRegistrationOptionsBuilder> optionsBuilder = null)
            where TMemoryDbContext : VfpContext
        {
            var options = new AbpVfpContextRegistrationOptions(typeof(TMemoryDbContext), services);
            optionsBuilder?.Invoke(options);

            if (options.DefaultRepositoryDbContextType != typeof(TMemoryDbContext))
            {
                services.TryAddSingleton(options.DefaultRepositoryDbContextType, sp => sp.GetRequiredService<TMemoryDbContext>());
            }

            foreach (var dbContextType in options.ReplacedDbContextTypes)
            {
                services.Replace(ServiceDescriptor.Singleton(dbContextType, sp => sp.GetRequiredService<TMemoryDbContext>()));
            }

            new VfpRepositoryRegistrar(options).AddRepositories();

            return services;
        }
    }
}
