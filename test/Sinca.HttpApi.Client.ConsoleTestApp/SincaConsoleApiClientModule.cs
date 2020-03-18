using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Sinca.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(SincaHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class SincaConsoleApiClientModule : AbpModule
    {
        
    }
}
