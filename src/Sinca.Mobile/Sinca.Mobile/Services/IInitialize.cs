using Volo.Abp;

namespace Sinca.Mobile.Services
{
    public interface IInitialize
    {
        IAbpApplicationWithInternalServiceProvider Application { get; set; }
    }
}
