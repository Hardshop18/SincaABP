using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.TestApp2.Domain;

namespace Volo.Abp.TestApp2
{
    public class TestDataBuilder : ITransientDependency
    {
        public static string TenantId1 { get; } = "55687dce-595c-41b4-a024-2a5e991ac8f4";
        public static string TenantId2 { get; } = "f522d19f-5a86-4278-98fb-0577319c544a";
        public static string UserDouglasId { get; } = "1fcf46b2-28c3-48d0-8bac-fa53268a2775";
        public static string UserJohnDeletedId { get; } = "1e28ca9f-df84-4f39-83fe-f5450ecbf5d4";

        public static string IstanbulCityId { get; } = "4d734a0e-3e6b-4bad-bb43-ef8cf1b09633";
        public static string LondonCityId { get; } = "27237527-605e-4652-a2a5-68e0e512da36";

        private readonly IBasicRepository<Person, string> _personRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IRepository<EntityWithIntPk, int> _entityWithIntPksRepository;

        public TestDataBuilder(
            IBasicRepository<Person, string> personRepository, 
            ICityRepository cityRepository,
            IRepository<EntityWithIntPk, int> entityWithIntPksRepository)
        {
            _personRepository = personRepository;
            _cityRepository = cityRepository;
            _entityWithIntPksRepository = entityWithIntPksRepository;
        }

        public async Task BuildAsync()
        {
            await AddCities();
            await AddPeople();
            await AddEntitiesWithPks();
        }

        private async Task AddCities()
        {
            var istanbul = new City(IstanbulCityId, "Istanbul");
            istanbul.Districts.Add(new District(istanbul.Id, "Bakirkoy", 1283999));
            istanbul.Districts.Add(new District(istanbul.Id, "Mecidiyekoy", 2222321));
            istanbul.Districts.Add(new District(istanbul.Id, "Uskudar", 726172));

            await _cityRepository.InsertAsync(new City(Guid.NewGuid().ToString(), "Tokyo"));
            await _cityRepository.InsertAsync(new City(Guid.NewGuid().ToString(), "Madrid"));
            await _cityRepository.InsertAsync(new City(LondonCityId.ToString(), "London") { ExtraProperties = { { "Population", 10_470_000 } } });
            await _cityRepository.InsertAsync(istanbul);
            await _cityRepository.InsertAsync(new City(Guid.NewGuid().ToString(), "Paris"));
            await _cityRepository.InsertAsync(new City(Guid.NewGuid().ToString(), "Washington"));
            await _cityRepository.InsertAsync(new City(Guid.NewGuid().ToString(), "Sao Paulo"));
            await _cityRepository.InsertAsync(new City(Guid.NewGuid().ToString(), "Berlin"));
            await _cityRepository.InsertAsync(new City(Guid.NewGuid().ToString(), "Amsterdam"));
            await _cityRepository.InsertAsync(new City(Guid.NewGuid().ToString(), "Beijing"));
            await _cityRepository.InsertAsync(new City(Guid.NewGuid().ToString(), "Rome"));
        }

        private async Task AddPeople()
        {
            var douglas = new Person(UserDouglasId.ToString(), "Douglas", 42, cityId: LondonCityId.ToString());
            douglas.Phones.Add(new Phone(douglas.Id.ToString(), "123456789"));
            douglas.Phones.Add(new Phone(douglas.Id, "123456780", PhoneType.Home));

            await _personRepository.InsertAsync(douglas);

            await _personRepository.InsertAsync(new Person(UserJohnDeletedId, "John-Deleted", 33) { IsDeleted = true });

            var tenant1Person1 = new Person(Guid.NewGuid().ToString(), TenantId1 + "-Person1", 42, TenantId1.ToString());
            var tenant1Person2 = new Person(Guid.NewGuid().ToString(), TenantId1 + "-Person2", 43, TenantId1.ToString());

            await _personRepository.InsertAsync(tenant1Person1);
            await _personRepository.InsertAsync(tenant1Person2);
        }

        private async Task AddEntitiesWithPks()
        {
            await _entityWithIntPksRepository.InsertAsync(new EntityWithIntPk("Entity1"));
        }
    }
}