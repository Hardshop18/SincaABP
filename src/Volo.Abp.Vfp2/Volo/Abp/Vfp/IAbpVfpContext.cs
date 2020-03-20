using System.Data.Entity;

namespace Volo.Abp.Vfp2
{
    public interface IAbpVfpContext
    {
        Database Database { get; }
    }
}