using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.Vfp2;

namespace Volo.Abp.Vfp2.DependencyInjection
{
    public class VfpRepositoryRegistrar : RepositoryRegistrarBase<AbpVfpContextRegistrationOptions>
    {
        public VfpRepositoryRegistrar(AbpVfpContextRegistrationOptions options)
            : base(options)
        {

        }

        protected override IEnumerable<Type> GetEntityTypes(Type dbContextType)
        {
            return VfpContextHelper.GetEntityTypes(dbContextType);
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