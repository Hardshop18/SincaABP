using System.Collections.Generic;

namespace Volo.Abp.Domain.Repositories.Vfp
{
    public interface IVfpCollection<TEntity> : IEnumerable<TEntity>
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}