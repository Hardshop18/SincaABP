using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Volo.Abp.Specifications;
using Volo.Abp.TestApp2.Domain;
using Xunit;

namespace Volo.Abp.TestApp2.Testing
{
    public abstract class Repository_Specifications_Tests<TStartupModule> : TestAppTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        protected readonly IRepository<City, string> CityRepository;

        protected Repository_Specifications_Tests()
        {
            CityRepository = GetRequiredService<IRepository<City, string>>();
        }

        [Fact]
        public async Task SpecificationWithRepository_Test()
        {
            await WithUnitOfWorkAsync(() =>
            {
                CityRepository.Count(new CitySpecification().ToExpression()).ShouldBe(1);
                return Task.CompletedTask;
            });
        }
    }

    public class CitySpecification : Specification<City>
    {
        public override Expression<Func<City, bool>> ToExpression()
        {
            return city => city.Name == "Istanbul";
        }
    }
}