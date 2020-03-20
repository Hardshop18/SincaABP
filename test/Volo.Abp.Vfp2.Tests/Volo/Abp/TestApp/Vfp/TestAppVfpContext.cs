using Volo.Abp.Data;
using Volo.Abp.Vfp2;
using Volo.Abp.TestApp.Domain;
using System.Data.Entity;

namespace Volo.Abp.TestApp.Vfp2
{
    [ConnectionStringName("TestApp")]
    public class TestAppVfpContext : AbpVfpContext, ITestAppVfpContext
    {
        public TestAppVfpContext() : base(@"D:\GitHub\dados\SincaTeste.dbc")
        {
        }

        [VfpCollection("Persons")] //Intentionally changed the collection name to test it
        public DbSet<Person> People { get; } // => Collection<Person>();

        public DbSet<EntityWithIntPk> EntityWithIntPks { get; } //=> Collection<EntityWithIntPk>();

        public DbSet<City> Cities { get; } //=> Collection<City>();

        protected override void CreateModel(IVfpModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.Entity<City>(b =>
            {
                b.CollectionName = "MyCities";
            });
        }
    }
}
