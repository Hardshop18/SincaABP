using System;
using System.Collections.Concurrent;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
//using MongoDB.Driver;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Reflection;

namespace Volo.Abp.Vfp2
{
    public class VfpModelSource : IVfpModelSource, ISingletonDependency
    {
        protected readonly ConcurrentDictionary<Type, VfpContextModel> ModelCache = new ConcurrentDictionary<Type, VfpContextModel>();
        
        public virtual VfpContextModel GetModel(AbpVfpContext dbContext)
        {
            return ModelCache.GetOrAdd(
                dbContext.GetType(),
                _ => CreateModel(dbContext)
            );
        }

        protected virtual VfpContextModel CreateModel(AbpVfpContext dbContext)
        {
            var modelBuilder = CreateModelBuilder();
            BuildModelFromDbContextType(modelBuilder, dbContext.GetType());
            BuildModelFromDbContextInstance(modelBuilder, dbContext);
            return modelBuilder.Build();
        }

        protected virtual VfpModelBuilder CreateModelBuilder()
        {
            return new VfpModelBuilder();
        }

        protected virtual void BuildModelFromDbContextType(IVfpModelBuilder modelBuilder, Type dbContextType)
        {
            var collectionProperties =
                from property in dbContextType.GetTypeInfo().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                where
                    ReflectionHelper.IsAssignableToGenericType(property.PropertyType, typeof(DbSet<>)) &&
                    typeof(IEntity).IsAssignableFrom(property.PropertyType.GenericTypeArguments[0])
                select property;

            foreach (var collectionProperty in collectionProperties)
            {
                BuildModelFromDbContextCollectionProperty(modelBuilder, collectionProperty);
            }
        }

        protected virtual void BuildModelFromDbContextCollectionProperty(IVfpModelBuilder modelBuilder, PropertyInfo collectionProperty)
        {
            var entityType = collectionProperty.PropertyType.GenericTypeArguments[0];
            var collectionAttribute = collectionProperty.GetCustomAttributes().OfType<VfpCollectionAttribute>().FirstOrDefault();

            modelBuilder.Entity(entityType, b =>
            {
                b.CollectionName = collectionAttribute?.CollectionName ?? collectionProperty.Name;
            });
        }

        protected virtual void BuildModelFromDbContextInstance(IVfpModelBuilder modelBuilder, AbpVfpContext dbContext)
        {
            dbContext.CreateModel(modelBuilder);
        }
    }
}