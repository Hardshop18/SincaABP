using System;
using System.Collections.Generic;
using System.Linq;

namespace Volo.Abp.EntityFramework.ValueComparers
{
    public class AbpDictionaryValueComparer<TKey, TValue> : ValueComparer<Dictionary<TKey, TValue>>
    {
        public AbpDictionaryValueComparer()
            : base(
                  (d1, d2) => d1.SequenceEqual(d2),
                  d => d.Aggregate(0, (k, v) => HashCode.Combine(k, v.GetHashCode())),
                  d => d.ToDictionary(k => k.Key, v => v.Value))
        {
        }
    }
}
