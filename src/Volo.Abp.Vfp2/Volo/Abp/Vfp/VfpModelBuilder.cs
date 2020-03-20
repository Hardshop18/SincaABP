using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Volo.Abp.Domain.Entities;

namespace Volo.Abp.Vfp2
{
    public class VfpModelBuilder : IVfpModelBuilder
    {
        private readonly Dictionary<Type, object> _entityModelBuilders;

        private static readonly object SyncObj = new object();

        public VfpModelBuilder()
        {
            _entityModelBuilders = new Dictionary<Type, object>();
        }

        public VfpContextModel Build()
        {
            lock (SyncObj)
            {
                var entityModels = _entityModelBuilders
                    .Select(x => x.Value)
                    .Cast<IVfpEntityModel>()
                    .ToImmutableDictionary(x => x.EntityType, x => x);

                var baseClasses = new List<Type>();

                foreach (var entityModel in entityModels.Values)
                {
                    var map = entityModel.As<IHasBsonClassMap>().GetMap();
                    if (!BsonClassMap.IsClassMapRegistered(map.ClassType))
                    {
                        BsonClassMap.RegisterClassMap(map);
                    }

                    baseClasses.AddRange(entityModel.EntityType.GetBaseClasses(includeObject: false));
                }

                baseClasses = baseClasses.Distinct().ToList();

                foreach (var baseClass in baseClasses)
                {
                    if (!BsonClassMap.IsClassMapRegistered(baseClass))
                    {
                        var map = new BsonClassMap(baseClass);
                        map.ConfigureAbpConventions();
                        BsonClassMap.RegisterClassMap(map);
                    }
                }

                return new VfpContextModel(entityModels);
            }
        }

        public virtual void Entity<TEntity>(Action<IVfpEntityModelBuilder<TEntity>> buildAction = null)
        {
            var model = (IVfpEntityModelBuilder<TEntity>)_entityModelBuilders.GetOrAdd(
                typeof(TEntity),
                () => new VfpEntityModelBuilder<TEntity>()
            );

            buildAction?.Invoke(model);
        }

        public virtual void Entity(Type entityType, Action<IVfpEntityModelBuilder> buildAction = null)
        {
            Check.NotNull(entityType, nameof(entityType));

            var model = (IVfpEntityModelBuilder)_entityModelBuilders.GetOrAdd(
                entityType,
                () => (IVfpEntityModelBuilder)Activator.CreateInstance(
                    typeof(VfpEntityModelBuilder<>).MakeGenericType(entityType)
                )
            );

            buildAction?.Invoke(model);
        }

        public virtual IReadOnlyList<IVfpEntityModel> GetEntities()
        {
            return _entityModelBuilders.Values.Cast<IVfpEntityModel>().ToImmutableList();
        }
    }
}