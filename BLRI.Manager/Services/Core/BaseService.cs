using BLRI.DAL.Interfaces.Core;

namespace BLRI.Manager.Services.Core
{
    public class BaseService
    {
        protected readonly IUnitOfWork UnitOfWork;

        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
