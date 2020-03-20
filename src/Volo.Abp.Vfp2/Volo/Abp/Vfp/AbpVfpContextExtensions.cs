namespace Volo.Abp.Vfp2
{
    public static class AbpVfpContextExtensions
    {
        public static AbpVfpContext ToAbpVfpContext(this IAbpVfpContext dbContext)
        {
            var abpVfpContext = dbContext as AbpVfpContext;

            if (abpVfpContext == null)
            {
                throw new AbpException($"The type {dbContext.GetType().AssemblyQualifiedName} should be convertable to {typeof(AbpVfpContext).AssemblyQualifiedName}!");
            }

            return abpVfpContext;
        }
    }
}