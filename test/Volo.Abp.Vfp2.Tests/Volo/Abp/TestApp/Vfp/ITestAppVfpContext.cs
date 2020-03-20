using Volo.Abp.Data;
using Volo.Abp.Vfp2;
using Volo.Abp.TestApp.Domain;
using System.Data.Entity;

namespace Volo.Abp.TestApp.Vfp2
{
    [ConnectionStringName("TestApp")]
    public interface ITestAppVfpContext : IAbpVfpContext
    {
        DbSet<Person> People { get; }

        DbSet<City> Cities { get; }
    }
}