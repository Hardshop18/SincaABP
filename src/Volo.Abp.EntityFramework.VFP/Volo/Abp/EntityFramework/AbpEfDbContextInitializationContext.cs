using Volo.Abp.Uow;

namespace Volo.Abp.EntityFramework
{
    public class AbpEfDbContextInitializationContext
    {
        public IUnitOfWork UnitOfWork { get; }

        public AbpEfDbContextInitializationContext(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}