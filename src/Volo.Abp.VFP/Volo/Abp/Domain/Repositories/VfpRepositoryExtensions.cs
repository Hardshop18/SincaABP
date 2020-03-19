using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.Vfp;

namespace Volo.Abp.Domain.Repositories
{
    public static class VfpRepositoryExtensions
    {
        public static IVfp GetDatabase<TEntity, TKey>(this IBasicRepository<TEntity, TKey> repository)
            where TEntity : class, IEntity<TKey>
        {
            return repository.ToVfpRepository().Database;
        }

        public static IVfpCollection<TEntity> GetCollection<TEntity, TKey>(this IBasicRepository<TEntity, TKey> repository)
            where TEntity : class, IEntity<TKey>
        {
            return repository.ToVfpRepository().Collection;
        }

        public static IVfpRepository<TEntity, TKey> ToVfpRepository<TEntity, TKey>(this IBasicRepository<TEntity, TKey> repository)
            where TEntity : class, IEntity<TKey>
        {
            var memoryDbRepository = repository as IVfpRepository<TEntity, TKey>;
            if (memoryDbRepository == null)
            {
                throw new ArgumentException("Given repository does not implement " + typeof(IVfpRepository<TEntity, TKey>).AssemblyQualifiedName, nameof(repository));
            }

            return memoryDbRepository;
        }
    }
}