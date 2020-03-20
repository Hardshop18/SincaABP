using System;

namespace Volo.Abp.Vfp2
{
    public interface IVfpEntityModel
    {
        Type EntityType { get; }

        string CollectionName { get; }
    }
}