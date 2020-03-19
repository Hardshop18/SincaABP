using System.Data.Entity;
using Volo.Abp.Domain.Entities;

namespace Volo.Abp.Domain.Repositories.EntityFramework
{
    public interface IEfRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        DbContext DbContext { get; }

        DbSet<TEntity> DbSet { get; }
    }

    public interface IEfRepository<TEntity, TKey> : IEfRepository<TEntity>, IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {

    }
}