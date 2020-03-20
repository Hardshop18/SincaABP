using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Vfp;

namespace Volo.Abp.Domain.Repositories.Vfp
{
    public class VfpRepository<TVfpContext, TEntity> : RepositoryBase<TEntity>, IVfpRepository<TEntity>
        where TVfpContext : VfpContext
        where TEntity : class, IEntity
    {
        //TODO: Add dbcontext just like VFP implementation!
        public DbSet<TEntity> DbSet;
        public virtual IVfpCollection<TEntity> Collection => Database.Collection<TEntity>();

        public virtual IVfp Database => DatabaseProvider.GetDatabase();

        protected IVfpProvider<TVfpContext> DatabaseProvider { get; }

        public VfpRepository(IVfpProvider<TVfpContext> databaseProvider)
        {
            DatabaseProvider = databaseProvider;
        }

        protected override IQueryable<TEntity> GetQueryable()
        {
            return ApplyDataFilters(DbSet.AsQueryable());
        }

        public override Task<TEntity> FindAsync(
            Expression<Func<TEntity, bool>> predicate,
            bool includeDetails = true,
            CancellationToken cancellationToken = default)
        {
            return Task.FromResult(DbSet.Where(predicate).SingleOrDefault());
        }

        public override Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var entities = DbSet.AsQueryable().Where(predicate).ToList();
            foreach (var entity in entities)
            {
                DbSet.Remove(entity);
            }

            return Task.CompletedTask;
        }

        public override Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            DbSet.Add(entity);
            return Task.FromResult(entity);
        }

        public override Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            DbSet.Add(entity);// Update
            return Task.FromResult(entity);
        }

        public override Task DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            DbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public override Task<List<TEntity>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(DbSet.ToList());
        }

        public override Task<long> GetCountAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(DbSet.LongCount());
        }
    }

    public class VfpRepository<TVfpContext, TEntity, TKey> : VfpRepository<TVfpContext, TEntity>, IVfpRepository<TEntity, TKey>
        where TVfpContext : VfpContext
        where TEntity : class, IEntity<TKey>
    {
        public VfpRepository(IVfpProvider<TVfpContext> databaseProvider)
            : base(databaseProvider)
        {
        }

        public override Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            SetIdIfNeeded(entity);
            return base.InsertAsync(entity, autoSave, cancellationToken);
        }

        protected virtual void SetIdIfNeeded(TEntity entity)
        {
            if (typeof(TKey) == typeof(int) ||
                typeof(TKey) == typeof(long) ||
                typeof(TKey) == typeof(Guid))
            {
                if (EntityHelper.HasDefaultId(entity))
                {
                    EntityHelper.TrySetId(entity, () => Database.GenerateNextId<TEntity, TKey>());
                }
            }
        }

        public virtual async Task<TEntity> GetAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            var entity = await FindAsync(id, includeDetails, cancellationToken);

            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(TEntity), id);
            }

            return entity;
        }

        public virtual Task<TEntity> FindAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(GetQueryable().FirstOrDefault(e => e.Id.Equals(id)));
        }

        public virtual async Task DeleteAsync(TKey id, bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var entity = await FindAsync(id, cancellationToken: cancellationToken);
            if (entity == null)
            {
                return;
            }

            await DeleteAsync(entity, autoSave, cancellationToken);
        }
    }
}