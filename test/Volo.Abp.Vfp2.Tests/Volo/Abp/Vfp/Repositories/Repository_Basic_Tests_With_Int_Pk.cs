using System.Threading.Tasks;
using Volo.Abp.TestApp2.Testing;
using Xunit;

namespace Volo.Abp.Vfp2.Repositories
{
    public class Repository_Basic_Tests_With_Int_Pk : Repository_Basic_Tests_With_Int_Pk<AbpVfpTestModule>
    {
        [Fact(Skip = "Int PKs are not working for VFP")]
        public override Task Get()
        {
            return Task.CompletedTask;
        }
    }
}