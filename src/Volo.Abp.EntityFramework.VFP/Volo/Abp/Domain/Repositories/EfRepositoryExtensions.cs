using System;
using System.Data.Entity;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFramework;

namespace Volo.Abp.Domain.Repositories
{
    //TODO: Should work for any IRepository implementation

    public static class EfRepositoryExtensions
    {
        public static DbContext GetDbContext<TEntity, TKey>(this IReadOnlyBasicRepository<TEntity, TKey> repository)
            where TEntity : class, IEntity<TKey>
        {
            return repository.ToEfRepository().DbContext;
        }

        public static DbSet<TEntity> GetDbSet<TEntity, TKey>(this IReadOnlyBasicRepository<TEntity, TKey> repository)
            where TEntity : class, IEntity<TKey>
        {
            return repository.ToEfRepository().DbSet;
        }

        public static IEfRepository<TEntity, TKey> ToEfRepository<TEntity, TKey>(this IReadOnlyBasicRepository<TEntity, TKey> repository)
            where TEntity : class, IEntity<TKey>
        {
            var efRepository = repository as IEfRepository<TEntity, TKey>;
            if (efRepository == null)
            {
                throw new ArgumentException("Given repository does not implement " + typeof(IEfRepository<TEntity, TKey>).AssemblyQualifiedName, nameof(repository));
            }

            return efRepository;
        }
    }
}
