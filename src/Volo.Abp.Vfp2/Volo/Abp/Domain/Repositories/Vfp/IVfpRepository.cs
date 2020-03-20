using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Volo.Abp.Domain.Entities;

namespace Volo.Abp.Domain.Repositories.Vfp2
{
    public interface IVfpRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        Database Database { get; }

        DbSet<TEntity> Collection { get; }

        IQueryable<TEntity> GetVfpQueryable();
    }

    public interface IVfpRepository<TEntity, TKey> : IVfpRepository<TEntity>, IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {

    }
}
