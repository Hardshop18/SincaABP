using System;
using System.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.Vfp2;

namespace Volo.Abp.Uow.Vfp2
{
    public class UnitOfWorkVfpContextProvider<TVfpContext> : IVfpContextProvider<TVfpContext>
        where TVfpContext : IAbpVfpContext
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IConnectionStringResolver _connectionStringResolver;

        public UnitOfWorkVfpContextProvider(
            IUnitOfWorkManager unitOfWorkManager,
            IConnectionStringResolver connectionStringResolver)
        {
            _unitOfWorkManager = unitOfWorkManager;
            _connectionStringResolver = connectionStringResolver;
        }

        public TVfpContext GetDbContext()
        {
            var unitOfWork = _unitOfWorkManager.Current;
            if (unitOfWork == null)
            {
                throw new AbpException($"A {nameof(Database)} instance can only be created inside a unit of work!");
            }

            var connectionString = _connectionStringResolver.Resolve<TVfpContext>();
            var dbContextKey = $"{typeof(TVfpContext).FullName}_{connectionString}";

            var mongoUrl = new MongoUrl(connectionString);
            var databaseName = mongoUrl.DatabaseName;
            if (databaseName.IsNullOrWhiteSpace())
            {
                databaseName = ConnectionStringNameAttribute.GetConnStringName<TVfpContext>();
            }

            //TODO: Create only single MongoDbClient per connection string in an application (extract MongoClientCache for example).
            var databaseApi = unitOfWork.GetOrAddDatabaseApi(
                dbContextKey,
                () =>
                {
                    var database = new MongoClient(mongoUrl).GetDatabase(databaseName);

                    var dbContext = unitOfWork.ServiceProvider.GetRequiredService<TVfpContext>();

                    dbContext.ToAbpVfpContext().InitializeDatabase(database);

                    return new VfpDatabaseApi<TVfpContext>(dbContext);
                });

            return ((VfpDatabaseApi<TVfpContext>)databaseApi).DbContext;
        }
    }
}