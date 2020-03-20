using Volo.Abp.Domain.Repositories.Vfp;

namespace Volo.Abp.Vfp
{
    public interface IVfpProvider<TVfpContext>
        where TVfpContext : VfpContext
    {
        TVfpContext DbContext { get; }

        IVfp GetDatabase();
    }
}