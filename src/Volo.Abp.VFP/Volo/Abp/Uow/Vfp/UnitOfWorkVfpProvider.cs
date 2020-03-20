using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories.Vfp;
using Volo.Abp.Vfp;

namespace Volo.Abp.Uow.Vfp
{
    public class UnitOfWorkVfpProvider<TVfpContext> : IVfpProvider<TVfpContext>
        where TVfpContext : VfpContext
    {
        public TVfpContext DbContext { get; }
        
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IConnectionStringResolver _connectionStringResolver;
        private readonly VfpManager _vfpManager;

        public UnitOfWorkVfpProvider(
            IUnitOfWorkManager unitOfWorkManager,
            IConnectionStringResolver connectionStringResolver,
            TVfpContext dbContext, 
            VfpManager vfpManager)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _connectionStringResolver = connectionStringResolver;
            DbContext = dbContext;
            _vfpManager = vfpManager;
        }

        public IVfp GetDatabase()
        {
            var unitOfWork = _unitOfWorkManager.Current;
            if (unitOfWork == null)
            {
                throw new AbpException($"A {nameof(IVfp)} instance can only be created inside a unit of work!");
            }

            var connectionString = _connectionStringResolver.Resolve<TVfpContext>();
            var dbContextKey = $"{typeof(TVfpContext).FullName}_{connectionString}";

            var databaseApi = unitOfWork.GetOrAddDatabaseApi(
                dbContextKey,
                () => new VfpDatabaseApi(
                    _vfpManager.Get(connectionString)
                ));

            return ((VfpDatabaseApi)databaseApi).Database;
        }
    }
}