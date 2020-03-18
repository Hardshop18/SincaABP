using Sinca.Localization;
using Volo.Abp.Application.Services;

namespace Sinca
{
    /* Inherit your application services from this class.
     */
    public abstract class SincaAppService : ApplicationService
    {
        protected SincaAppService()
        {
            LocalizationResource = typeof(SincaResource);
        }
    }
}
