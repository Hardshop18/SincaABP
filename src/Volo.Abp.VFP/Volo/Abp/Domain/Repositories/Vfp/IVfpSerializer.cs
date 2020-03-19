using System;

namespace Volo.Abp.Domain.Repositories.Vfp
{
    public interface IVfpSerializer
    {
        byte[] Serialize(object obj);

        object Deserialize(byte[] value, Type type);
    }
}