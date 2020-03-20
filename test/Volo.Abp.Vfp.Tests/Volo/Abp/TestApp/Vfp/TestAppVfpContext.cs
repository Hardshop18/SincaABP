using System;
using System.Collections.Generic;
using Volo.Abp.Vfp;
using Volo.Abp.TestApp.Domain;

namespace Volo.Abp.TestApp.Vfp
{
    public class TestAppVfpContext : VfpContext
    {
        public TestAppVfpContext() : base(@"D:\GitHub\dados\SincaTeste.dbc")
        { }

        private static readonly Type[] EntityTypeList = {
            typeof(Person),
            typeof(EntityWithIntPk)
        };

        public override IReadOnlyList<Type> GetEntityTypes()
        {
            return EntityTypeList;
        }
    }
}
