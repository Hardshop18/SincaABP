using Sinca.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Sinca
{
    [DependsOn(
        typeof(SincaEntityFrameworkCoreTestModule)
        )]
    public class SincaDomainTestModule : AbpModule
    {

    }
}