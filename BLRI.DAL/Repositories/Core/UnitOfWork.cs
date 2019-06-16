using System;
using System.Threading.Tasks;
using BLRI.DAL.Interfaces.Core;
using BLRI.DAL.Interfaces.LookUp;
using BLRI.DAL.Repositories.Lookup;


namespace BLRI.DAL.Repositories.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public IAnimalCategoryRepository AnimalCategoryRepository { get; }
        public IDropdownRepository DropdownRepository { get; }

        //        public IChatFileRepository ChatFileRepository { get; }
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            DropdownRepository = new DropdownRepository(_dbContext);

            AnimalCategoryRepository = new AnimalCategoryRepository(_dbContext);
//            ApkRepository = new ApkRepository(_dbContext);
//            ChatFileRepository = new ChatFileRepository(_dbContext);
        }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}