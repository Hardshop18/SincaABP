using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace Sinca.Web
{
    [Dependency(ReplaceServices = true)]
    public class SincaBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Sinca";
    }
}
