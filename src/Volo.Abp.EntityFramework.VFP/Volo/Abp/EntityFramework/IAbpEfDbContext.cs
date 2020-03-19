namespace Volo.Abp.EntityFramework
{
    public interface IAbpEfDbContext : IEfDbContext
    {
        void Initialize(AbpEfDbContextInitializationContext initializationContext);
    }
}