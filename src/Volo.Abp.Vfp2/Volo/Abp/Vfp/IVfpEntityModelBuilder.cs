using System;
using MongoDB.Bson.Serialization;

namespace Volo.Abp.Vfp2
{
    public interface IVfpEntityModelBuilder<TEntity>
    {
        Type EntityType { get; }

        string CollectionName { get; set; }

        BsonClassMap<TEntity> BsonMap { get; }
    }

    public interface IVfpEntityModelBuilder
    {
        Type EntityType { get; }

        string CollectionName { get; set; }

        BsonClassMap BsonMap { get; }
    }
}