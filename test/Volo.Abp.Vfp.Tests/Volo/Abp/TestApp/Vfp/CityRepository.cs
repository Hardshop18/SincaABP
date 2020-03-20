using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.Vfp;
using Volo.Abp.Vfp;
using Volo.Abp.TestApp.Domain;

namespace Volo.Abp.TestApp.Vfp
{
    public class CityRepository : VfpRepository<TestAppVfpContext, City, Guid>, ICityRepository
    {
        public CityRepository(IVfpProvider<TestAppVfpContext> databaseProvider) 
            : base(databaseProvider)
        {
        }

        public Task<City> FindByNameAsync(string name)
        {
            return Task.FromResult(DbSet.FirstOrDefault(c => c.Name == name));
        }

        public async Task<List<Person>> GetPeopleInTheCityAsync(string cityName)
        {
            var city = await FindByNameAsync(cityName);

            return Database.Collection<Person>().Where(p => p.CityId == city.Id).ToList();
        }
    }
}
