using Volo.Abp.Testing;

namespace Volo.Abp.Vfp2
{
    public abstract class VfpTestBase : AbpIntegratedTest<AbpVfpTestModule>
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}