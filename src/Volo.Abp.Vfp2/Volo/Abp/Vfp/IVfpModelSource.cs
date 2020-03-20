namespace Volo.Abp.Vfp2
{
    public interface IVfpModelSource
    {
        VfpContextModel GetModel(AbpVfpContext dbContext);
    }
}