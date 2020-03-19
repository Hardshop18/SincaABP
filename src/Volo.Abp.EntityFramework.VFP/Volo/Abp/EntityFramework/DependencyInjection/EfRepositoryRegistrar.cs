using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFramework;
using Volo.Abp.EntityFramework;
using Volo.Abp.EntityFramework.DependencyInjection;

namespace Volo.Abp.EntityFrameworkCore.DependencyInjection
{
    public class EfRepositoryRegistrar : RepositoryRegistrarBase<AbpDbContextRegistrationOptions>
    {
        public EfRepositoryRegistrar(AbpDbContextRegistrationOptions options)
            : base(options)
        {

        }

        protected override IEnumerable<Type> GetEntityTypes(Type dbContextType)
        {
            return DbContextHelper.GetEntityTypes(dbContextType);
        }

        protected override Type GetRepositoryType(Type dbContextType, Type entityType)
        {
            return typeof(EfRepository<,>).MakeGenericType(dbContextType, entityType);
        }

        protected override Type GetRepositoryType(Type dbContextType, Type entityType, Type primaryKeyType)
        {
            return typeof(EfCoreRepository<,,>).MakeGenericType(dbContextType, entityType, primaryKeyType);
        }
    }
}