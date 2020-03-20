using MongoDB.Driver;

namespace Volo.Abp.Vfp2
{
    public interface IAbpVfpContext
    {
        IVfpDatabase Database { get; }

        IVfpCollection<T> Collection<T>();
    }
}