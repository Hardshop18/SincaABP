using System;
using System.Collections.Generic;
using Volo.Abp.Vfp;
using Volo.Abp.TestApp2.Domain;
using System.Data.Entity;

namespace Volo.Abp.TestApp.Vfp
{
    public class TestAppVfpContext : VfpContext
    {
        public DbSet<Person> People { get; set; }

        public DbSet<EntityWithIntPk> Cities { get; set; }


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
