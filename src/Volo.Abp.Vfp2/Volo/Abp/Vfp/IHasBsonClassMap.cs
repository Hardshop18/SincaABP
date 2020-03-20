using MongoDB.Bson.Serialization;

namespace Volo.Abp.Vfp2
{
    public interface IHasBsonClassMap
    {
        BsonClassMap GetMap();
    }
}