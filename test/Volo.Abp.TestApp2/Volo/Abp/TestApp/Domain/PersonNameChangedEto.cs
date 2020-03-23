using System;

namespace Volo.Abp.TestApp2.Domain
{
    public class PersonNameChangedEto
    {
        public virtual string Id { get; set; }

        public virtual string? TenantId { get; set; }

        public string OldName { get; set; }

        public string NewName { get; set; }
    }
}