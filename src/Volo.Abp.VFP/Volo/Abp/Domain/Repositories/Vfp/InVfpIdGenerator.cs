using System;
using System.Threading;

namespace Volo.Abp.Domain.Repositories.Vfp
{
    internal class InVfpIdGenerator
    {
        private int _lastInt;
        private long _lastLong;

        public TKey GenerateNext<TKey>()
        {
            if (typeof(TKey) == typeof(string))
            {
                return (TKey)(object)Guid.NewGuid().ToString();
            }

            if (typeof(TKey) == typeof(Guid))
            {
                return (TKey)(object)Guid.NewGuid();
            }

            if (typeof(TKey) == typeof(int))
            {
                return (TKey)(object)Interlocked.Increment(ref _lastInt);
            }

            if (typeof(TKey) == typeof(long))
            {
                return (TKey)(object)Interlocked.Increment(ref _lastLong);
            }

            throw new AbpException("Not supported PrimaryKey type: " + typeof(TKey).FullName);
        }
    }
}