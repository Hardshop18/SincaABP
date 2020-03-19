using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Volo.Abp.Domain.Repositories.Vfp
{
    public interface IVfpRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        IVfp Database { get; }

        IVfpCollection<TEntity> Collection { get; }
    }

    public interface IVfpRepository<TEntity, TKey> : IVfpRepository<TEntity>, IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {

    }
}
