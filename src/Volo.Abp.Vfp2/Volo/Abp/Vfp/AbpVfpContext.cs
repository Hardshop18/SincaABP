using System.Collections.Generic;
using System.Data.Entity;
using VfpEntityFrameworkProvider;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.Vfp2
{
    [DbConfigurationType(typeof(VfpDbConfiguration))]
    public abstract class AbpVfpContext : DbContext, IAbpVfpContext, ITransientDependency
    {
        public IVfpModelSource ModelSource { get; set; }

        public IVfpDatabase Database { get; private set; }

        public AbpVfpContext(string connection)
            : base(new VfpConnection(connection), true)
        {
        }

        protected internal virtual void CreateModel(IVfpModelBuilder modelBuilder)
        {

        }

        public virtual void InitializeDatabase(IVfpDatabase database)
        {
            Database = database;
        }

        public virtual IVfpCollection<T> Collection<T>()
        {
            return Database.GetCollection<T>(GetCollectionName<T>());
        }

        protected virtual string GetCollectionName<T>()
        {
            return GetEntityModel<T>().CollectionName;
        }

        protected virtual IVfpEntityModel GetEntityModel<TEntity>()
        {
            var model = ModelSource.GetModel(this).Entities.GetOrDefault(typeof(TEntity));

            if (model == null)
            {
                throw new AbpException("Could not find a model for given entity type: " + typeof(TEntity).AssemblyQualifiedName);
            }

            return model;
        }
    }
}