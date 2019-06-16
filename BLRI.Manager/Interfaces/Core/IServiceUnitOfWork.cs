using System.Threading.Tasks;
using BLRI.Manager.Interfaces.LookUp;

namespace BLRI.Manager.Interfaces.Core
{
    public interface IServiceUnitOfWork
    {
        int Complete();
        Task<int> CompleteAsync();

        IAnimalCategoryManager AnimalCategoryManager{get;}

        IDropdownManager DropdownManager { get; set; }
//        IChatFileService ChatFileService { get; }

    }
}