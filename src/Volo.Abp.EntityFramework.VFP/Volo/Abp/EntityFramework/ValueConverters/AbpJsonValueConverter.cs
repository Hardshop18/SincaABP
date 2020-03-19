using Newtonsoft.Json;

namespace Volo.Abp.EntityFramework.ValueConverters
{
    public class AbpJsonValueConverter<TPropertyType> : ValueConverter<TPropertyType, string>
    {
        public AbpJsonValueConverter()
            : base(
                d => JsonConvert.SerializeObject(d, Formatting.None),
                s => JsonConvert.DeserializeObject<TPropertyType>(s))
        {
        }
    }
}
