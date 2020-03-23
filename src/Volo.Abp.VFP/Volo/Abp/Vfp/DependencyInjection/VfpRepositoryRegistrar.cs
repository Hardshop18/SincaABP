using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.Vfp;

namespace Volo.Abp.Vfp.DependencyInjection
{
    public class VfpRepositoryRegistrar : RepositoryRegistrarBase<AbpVfpContextRegistrationOptions>
    {
        public VfpRepositoryRegistrar(AbpVfpContextRegistrationOptions options)
            : base(options)
        {
        }

        protected override IEnumerable<Type> GetEntityTypes(Type dbContextType)
        {
            var memoryDbContext = new VfpContext(@"D:\GitHub\dados\SincaTeste.dbc");
            return memoryDbContext.GetEntityTypes();
        }

        protected override Type GetRepositoryType(Type dbContextType, Type entityType)
        {
            return typeof(VfpRepository<,>).MakeGenericType(dbContextType, entityType);
        }

        protected override Type GetRepositoryType(Type dbContextType, Type entityType, Type primaryKeyType)
        {
            return typeof(VfpRepository<,,>).MakeGenericType(dbContextType, entityType, primaryKeyType);
        }
    }
}