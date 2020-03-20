using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Volo.Abp.TestApp2.Domain
{
    public interface ICityRepository : IBasicRepository<City, string>
    {
        Task<City> FindByNameAsync(string name);

        Task<List<Person>> GetPeopleInTheCityAsync(string cityName);
    }
}
