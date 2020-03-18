using Sinca.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Sinca.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class SincaPageModel : AbpPageModel
    {
        protected SincaPageModel()
        {
            LocalizationResourceType = typeof(SincaResource);
        }
    }
}