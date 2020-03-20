using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Volo.Abp.TestApp2.Domain
{
    public interface IPersonRepository : IBasicRepository<Person, string>
    {
        Task<PersonView> GetViewAsync(string name);
    }
}
