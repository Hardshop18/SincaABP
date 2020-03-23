using System;
using Volo.Abp.Domain.Entities.Events.Distributed;

namespace Volo.Abp.TestApp2.Domain
{
    //[Serializable] //TODO: ???
    public class PersonEto : EntityEto
    {
        public virtual string? TenantId { get; set; }

        public virtual string? CityId { get; set; }

        public virtual string Name { get; set; }

        public virtual int Age { get; set; }
    }
}
