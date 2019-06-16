using System;
using System.Threading.Tasks;
using BLRI.DAL.Interfaces.LookUp;

namespace BLRI.DAL.Interfaces.Core
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
        Task<int> CompleteAsync();

        IAnimalCategoryRepository AnimalCategoryRepository { get; }
        IDropdownRepository DropdownRepository { get; }
//        IChatFileRepository ChatFileRepository { get; }
    }
}