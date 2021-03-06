using System;
using System.Collections.Generic;
using System.Data.Entity;
using VfpEntityFrameworkProvider;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.Vfp
{
    [DbConfigurationType(typeof(VfpDbConfiguration))]
    public class VfpContext : DbContext
    {
        private static readonly Type[] EmptyTypeList = new Type[0];

        public virtual IReadOnlyList<Type> GetEntityTypes()
        {
            return EmptyTypeList;
        }

        public VfpContext(string cs)
            : base(new VfpConnection(cs), true)
        {
        }
    }
}