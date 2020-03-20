using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Volo.Abp.Vfp2
{
    public interface IVfpModelBuilder
    {
        void Entity<TEntity>(Action<IVfpEntityModelBuilder<TEntity>> buildAction = null);

        void Entity([NotNull] Type entityType, Action<IVfpEntityModelBuilder> buildAction = null);

        IReadOnlyList<IVfpEntityModel> GetEntities();
    }
}