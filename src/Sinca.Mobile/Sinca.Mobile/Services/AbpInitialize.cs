using Volo.Abp;

namespace Sinca.Mobile.Services
{
    public class AbpInitialize : IInitialize
    {
        public IAbpApplicationWithInternalServiceProvider Application { get; set; }
        
        public AbpInitialize()
        {
            Application = AbpApplicationFactory.Create<SincaModule>(options =>
            {
                options.UseAutofac(); //Autofac integration
            });
            Application.Initialize();
        }
    }
}