using System.Collections.Generic;
using Volo.Abp.Auditing;

namespace Volo.Abp.EntityFramework.EntityHistory
{
    public interface IEntityHistoryHelper
    {
        List<EntityChangeInfo> CreateChangeList(ICollection<EntityEntry> entityEntries);

        void UpdateChangeList(List<EntityChangeInfo> entityChanges);
    }
}
