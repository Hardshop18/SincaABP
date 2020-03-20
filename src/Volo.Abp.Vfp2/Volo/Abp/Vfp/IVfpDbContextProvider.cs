namespace Volo.Abp.Vfp2
{
    public interface IVfpContextProvider<out TVfpContext>
        where TVfpContext : IAbpVfpContext
    {
        TVfpContext GetDbContext();
    }
}