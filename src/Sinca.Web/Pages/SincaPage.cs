using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Sinca.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Sinca.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits Sinca.Web.Pages.SincaPage
     */
    public abstract class SincaPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<SincaResource> L { get; set; }
    }
}
