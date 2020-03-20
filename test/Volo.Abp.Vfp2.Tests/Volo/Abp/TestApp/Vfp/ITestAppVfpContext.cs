using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.Vfp2;
using Volo.Abp.TestApp.Domain;

namespace Volo.Abp.TestApp.Vfp2
{
    [ConnectionStringName("TestApp")]
    public interface ITestAppVfpContext : IAbpVfpContext
    {
        IMongoCollection<Person> People { get; }

        IMongoCollection<City> Cities { get; }
    }
}