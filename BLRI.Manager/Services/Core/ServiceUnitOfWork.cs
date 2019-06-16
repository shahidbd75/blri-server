using System.Threading.Tasks;
using BLRI.DAL.Interfaces.Core;
using BLRI.DAL.Interfaces.LookUp;
using BLRI.DAL.Repositories.Lookup;
using BLRI.Manager.Interfaces.Core;
using BLRI.Manager.Interfaces.LookUp;
using BLRI.Manager.Services.LookUp;

namespace BLRI.Manager.Services.Core
{
    public class ServiceUnitOfWork : IServiceUnitOfWork
    {
        protected readonly IUnitOfWork UnitOfWork;    
//        public IApkService ApkService { get; }
//        public IChatFileService ChatFileService { get; }

        public ServiceUnitOfWork(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            AnimalCategoryManager = new AnimalCategoryManager(unitOfWork);
            DropdownManager = new DropdownManager(unitOfWork);
//            ChatFileService = new ChatFileService(unitOfWork);
        }
        public int Complete()
        {
            return UnitOfWork.Complete();
        }

        public Task<int> CompleteAsync()
        {
            return UnitOfWork.CompleteAsync();
        }

        public IAnimalCategoryManager AnimalCategoryManager { get; }
        public IDropdownManager DropdownManager { get; set; }
    }
}
