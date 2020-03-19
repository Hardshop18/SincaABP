using Volo.Abp.Domain.Entities;

namespace Volo.Abp.Domain.Repositories.Vfp
{
    public interface IVfp
    {
        IVfpCollection<TEntity> Collection<TEntity>() where TEntity : class, IEntity;

        TKey GenerateNextId<TEntity, TKey>();
    }
}