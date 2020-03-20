using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.Vfp2;

namespace Volo.Abp.Domain.Repositories
{
    public static class VfpCoreRepositoryExtensions
    {
        public static Database GetDatabase<TEntity, TKey>(this IBasicRepository<TEntity, TKey> repository)
            where TEntity : class, IEntity<TKey>
        {
            return repository.ToVfpRepository().Database;
        }

        public static IList<TEntity> GetCollection<TEntity, TKey>(this IBasicRepository<TEntity, TKey> repository)
            where TEntity : class, IEntity<TKey>
        {
            return repository.ToVfpRepository().ToList();
        }

        public static IQueryable<TEntity> GetVfpQueryable<TEntity, TKey>(this IBasicRepository<TEntity, TKey> repository)
            where TEntity : class, IEntity<TKey>
        {
            return repository.ToVfpRepository().GetVfpQueryable();
        }

        public static IVfpRepository<TEntity, TKey> ToVfpRepository<TEntity, TKey>(this IBasicRepository<TEntity, TKey> repository)
            where TEntity : class, IEntity<TKey>
        {
            var vfpRepository = repository as IVfpRepository<TEntity, TKey>;
            if (vfpRepository == null)
            {
                throw new ArgumentException("Given repository does not implement " + typeof(IVfpRepository<TEntity, TKey>).AssemblyQualifiedName, nameof(repository));
            }

            return vfpRepository;
        }
    }
}