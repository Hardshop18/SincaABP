using Sinca.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Sinca.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class SincaController : AbpController
    {
        protected SincaController()
        {
            LocalizationResource = typeof(SincaResource);
        }
    }
}