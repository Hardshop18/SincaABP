using Volo.Abp.Modularity;

namespace Sinca
{
    [DependsOn(
        typeof(SincaApplicationModule),
        typeof(SincaDomainTestModule)
        )]
    public class SincaApplicationTestModule : AbpModule
    {

    }
}