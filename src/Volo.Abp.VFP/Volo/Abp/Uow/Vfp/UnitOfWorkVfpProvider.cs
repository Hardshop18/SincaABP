using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories.Vfp;
using Volo.Abp.Vfp;

namespace Volo.Abp.Uow.Vfp
{
    public class UnitOfWorkVfpProvider<TMemoryDbContext> : IDatabaseProvider<TMemoryDbContext>
        where TMemoryDbContext : VfpContext
    {
        public TMemoryDbContext DbContext { get; }
        
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IConnectionStringResolver _connectionStringResolver;
        private readonly VfpManager _memoryDatabaseManager;

        public UnitOfWorkVfpProvider(
            IUnitOfWorkManager unitOfWorkManager,
            IConnectionStringResolver connectionStringResolver,
            TMemoryDbContext dbContext, 
            VfpManager memoryDatabaseManager)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _connectionStringResolver = connectionStringResolver;
            DbContext = dbContext;
            _memoryDatabaseManager = memoryDatabaseManager;
        }

        public IVfp GetDatabase()
        {
            var unitOfWork = _unitOfWorkManager.Current;
            if (unitOfWork == null)
            {
                throw new AbpException($"A {nameof(IVfp)} instance can only be created inside a unit of work!");
            }

            var connectionString = _connectionStringResolver.Resolve<TMemoryDbContext>();
            var dbContextKey = $"{typeof(TMemoryDbContext).FullName}_{connectionString}";

            var databaseApi = unitOfWork.GetOrAddDatabaseApi(
                dbContextKey,
                () => new VfpDatabaseApi(
                    _memoryDatabaseManager.Get(connectionString)
                ));

            return ((VfpDatabaseApi)databaseApi).Database;
        }
    }
}