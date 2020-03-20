namespace Volo.Abp.Uow.Vfp2
{
    public class VfpDatabaseApi<TVfpContext> : IDatabaseApi
    {
        public TVfpContext DbContext { get; }

        public VfpDatabaseApi(TVfpContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}
