using MongoDB.Bson.Serialization;
using System;

namespace Volo.Abp.Vfp2
{
    public class VfpEntityModelBuilder<TEntity> : 
        IVfpEntityModel, 
        IHasBsonClassMap,
        IVfpEntityModelBuilder,
        IVfpEntityModelBuilder<TEntity>
    {
        public Type EntityType { get; }

        public string CollectionName { get; set; }

        BsonClassMap IVfpEntityModelBuilder.BsonMap => _bsonClassMap;
        BsonClassMap<TEntity> IVfpEntityModelBuilder<TEntity>.BsonMap => _bsonClassMap;

        private readonly BsonClassMap<TEntity> _bsonClassMap;

        public VfpEntityModelBuilder()
        {
            EntityType = typeof(TEntity);
            _bsonClassMap = new BsonClassMap<TEntity>();
            _bsonClassMap.ConfigureAbpConventions();
        }

        public BsonClassMap GetMap()
        {
            return _bsonClassMap;
        }
    }
}