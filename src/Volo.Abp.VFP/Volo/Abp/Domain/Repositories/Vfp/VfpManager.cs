using System;
using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.Domain.Repositories.Vfp
{
    public class VfpManager : ISingletonDependency
    {
        private readonly ConcurrentDictionary<string, IVfp> _databases =
            new ConcurrentDictionary<string, IVfp>();

        private readonly IServiceProvider _serviceProvider;

        public VfpManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IVfp Get(string databaseName)
        {
            return _databases.GetOrAdd(databaseName, _ => _serviceProvider.GetRequiredService<IVfp>());
        }
    }
}