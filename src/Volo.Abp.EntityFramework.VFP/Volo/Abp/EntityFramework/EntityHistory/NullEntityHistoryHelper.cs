using System.Collections.Generic;
using Volo.Abp.Auditing;

namespace Volo.Abp.EntityFramework.EntityHistory
{
    public class NullEntityHistoryHelper : IEntityHistoryHelper
    {
        public static NullEntityHistoryHelper Instance { get; } = new NullEntityHistoryHelper();

        private NullEntityHistoryHelper()
        {

        }

        public List<EntityChangeInfo> CreateChangeList(ICollection<EntityEntry> entityEntries)
        {
            return new List<EntityChangeInfo>();
        }

        public void UpdateChangeList(List<EntityChangeInfo> entityChanges)
        {
            
        }
    }
}