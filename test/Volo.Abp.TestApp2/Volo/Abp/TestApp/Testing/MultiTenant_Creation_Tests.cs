using System;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Shouldly;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TestApp2.Application;
using Volo.Abp.TestApp2.Application.Dto;
using Volo.Abp.TestApp2.Domain;
using Xunit;

namespace Volo.Abp.TestApp2.Testing
{
    public abstract class MultiTenant_Creation_Tests<TStartupModule> : TestAppTestBase<TStartupModule> 
        where TStartupModule : IAbpModule
    {
        private ICurrentTenant _fakeCurrentTenant;
        private readonly IRepository<Person, string> _personRepository;
        private readonly IPeopleAppService _peopleAppService;

        protected MultiTenant_Creation_Tests()
        {
            _personRepository = GetRequiredService<IRepository<Person, string>>();
            _peopleAppService = GetRequiredService<IPeopleAppService>();
        }

        protected override void AfterAddApplication(IServiceCollection services)
        {
            _fakeCurrentTenant = Substitute.For<ICurrentTenant>();
            services.AddSingleton(_fakeCurrentTenant);
        }

        [Fact]
        public async void Should_Set_TenantId_For_New_Person()
        {
            _fakeCurrentTenant.Id.Returns(TestDataBuilder.TenantId1);

            var personId = Guid.NewGuid().ToString();
            await _peopleAppService.CreateAsync(new PersonDto
            {
                Id = personId,
                Name = "Person1",
                Age = 21
            });

            var person = await _personRepository.FindAsync(personId);

            person.ShouldNotBeNull();
            person.TenantId.ShouldNotBeNull();
            person.TenantId.ShouldNotBe(Guid.Empty);
            person.TenantId.ShouldBe(TestDataBuilder.TenantId1);
        }

        [Fact]
        public async void Should_Set_Null_TenantId_For_Host_Tenant()
        {
            _fakeCurrentTenant.Id.Returns((Guid?)null);

            var personId = Guid.NewGuid().ToString();
            await _peopleAppService.CreateAsync(new PersonDto
            {
                Id = personId,
                Name = "Person1",
                Age = 21
            });

            var person = await _personRepository.FindAsync(personId);

            person.ShouldNotBeNull();
            person.TenantId.ShouldBeNull();
        }
    }
}
