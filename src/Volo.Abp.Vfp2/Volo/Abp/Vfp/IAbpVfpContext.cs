using MongoDB.Driver;
using System.Collections.Generic;
using System.Data.Entity;

namespace Volo.Abp.Vfp2
{
    public interface IAbpVfpContext
    {
        Database Database { get; }

        IList<T> Collection<T>();
    }
}