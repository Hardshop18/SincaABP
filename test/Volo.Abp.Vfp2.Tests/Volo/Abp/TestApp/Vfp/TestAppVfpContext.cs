using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.Vfp2;
using Volo.Abp.TestApp.Domain;

namespace Volo.Abp.TestApp.MongoDB
{
    [ConnectionStringName("TestApp")]
    public class TestAppVfpContext : AbpVfpContext, ITestAppMongoDbContext
    {
        [VfpCollection("Persons")] //Intentionally changed the collection name to test it
        public ICollection<Person> People => Collection<Person>();

        public ICollection<EntityWithIntPk> EntityWithIntPks => Collection<EntityWithIntPk>();

        public ICollection<City> Cities => Collection<City>();

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
