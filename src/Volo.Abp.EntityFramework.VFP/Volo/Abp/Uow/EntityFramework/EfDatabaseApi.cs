using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.EntityFramework;

namespace Volo.Abp.Uow.EntityFramework
{
    public class EfDatabaseApi<TDbContext> : IDatabaseApi, ISupportsSavingChanges
        where TDbContext : IEfDbContext
    {
        public TDbContext DbContext { get; }

        public EfDatabaseApi(TDbContext dbContext)
        {
            DbContext = dbContext;
        }
        
        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return DbContext.SaveChangesAsync(cancellationToken);
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}