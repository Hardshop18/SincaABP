using Volo.Abp.Modularity;

namespace Volo.Abp.EntityFrameworkCore.VFP
{
    [DependsOn(
        typeof(AbpEntityFrameworkCoreModule)
        )]
    public class AbpEntityFrameworkCoreVFPModule : AbpModule
    {

    }
}
