﻿using System.Linq;
using Volo.Abp.Domain.Entities;

namespace Volo.Abp.Domain.Repositories.Vfp2
{
    public interface IVfpRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        IVfpDatabase Database { get; }

        IVfpCollection<TEntity> Collection { get; }

        IQueryable<TEntity> GetVfpQueryable();
    }

    public interface IVfpRepository<TEntity, TKey> : IVfpRepository<TEntity>, IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
    {

    }
}
