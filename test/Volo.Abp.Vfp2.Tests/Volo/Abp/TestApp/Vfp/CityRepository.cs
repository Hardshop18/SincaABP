using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Volo.Abp.Domain.Repositories.Vfp2;
using Volo.Abp.Vfp2;
using Volo.Abp.TestApp.Domain;
using System.Linq;

namespace Volo.Abp.TestApp.Vfp2
{
    public class CityRepository : VfpRepository<ITestAppVfpContext, City, string>, ICityRepository
    {
        public CityRepository(IVfpContextProvider<ITestAppVfpContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<City> FindByNameAsync(string name)
        {
            var city = Collection.FirstOrDefault(c => c.Name == name);
            return await Task.Run(() => city);
        }

        public async Task<List<Person>> GetPeopleInTheCityAsync(string cityName)
        {
            var city = await FindByNameAsync(cityName);
            var cities = DbContext.People.WhereIf(true, p => p.CityId == city.Id).ToList();
            return await Task.Run( () => cities);
        }
    }
}
