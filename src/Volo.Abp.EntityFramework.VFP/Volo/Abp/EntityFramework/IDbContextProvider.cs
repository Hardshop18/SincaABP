namespace Volo.Abp.EntityFramework
{
    public interface IDbContextProvider<out TDbContext>
        where TDbContext : IEfDbContext
    {
        TDbContext GetDbContext();
    }
}