using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;

namespace Volo.Abp.Domain.Repositories.Vfp
{
    public class Vfp : IVfp, ITransientDependency
    {
        private readonly ConcurrentDictionary<Type, object> _sets;

        private readonly ConcurrentDictionary<Type, InVfpIdGenerator> _entityIdGenerators;

        private readonly IServiceProvider _serviceProvider;

        public Vfp(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _sets = new ConcurrentDictionary<Type, object>();
            _entityIdGenerators = new ConcurrentDictionary<Type, InVfpIdGenerator>();
        }

        public IVfpCollection<TEntity> Collection<TEntity>()
            where TEntity : class, IEntity
        {
            return _sets.GetOrAdd(typeof(TEntity),
                    _ => _serviceProvider.GetRequiredService<IVfpCollection<TEntity>>()) as
                IVfpCollection<TEntity>;
        }

        public TKey GenerateNextId<TEntity, TKey>()
        {
            return _entityIdGenerators
                .GetOrAdd(typeof(TEntity), () => new InVfpIdGenerator())
                .GenerateNext<TKey>();
        }
    }
}