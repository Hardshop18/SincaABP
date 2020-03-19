using Volo.Abp.Domain.Repositories.Vfp;

namespace Volo.Abp.Uow.Vfp
{
    public class VfpDatabaseApi: IDatabaseApi
    {
        public IVfp Database { get; }

        public VfpDatabaseApi(IVfp database)
        {
            Database = database;
        }
    }
}
