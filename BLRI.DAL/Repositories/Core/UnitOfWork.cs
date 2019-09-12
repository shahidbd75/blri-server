using System;
using System.Threading.Tasks;
using BLRI.DAL.Interfaces.Animals;
using BLRI.DAL.Interfaces.Core;
using BLRI.DAL.Interfaces.LookUp;
using BLRI.DAL.Interfaces.Task;
using BLRI.DAL.Interfaces.Units;
using BLRI.DAL.Repositories.Animals;
using BLRI.DAL.Repositories.Lookup;
using BLRI.DAL.Repositories.Task;
using BLRI.DAL.Repositories.Units;


namespace BLRI.DAL.Repositories.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public IAnimalCategoryRepository AnimalCategoryRepository { get; }
        public IDropdownRepository DropdownRepository { get; }
        public IAnimalRepository AnimalRepository { get; }
        public IBiometricRepository BiometricRepository { get; }
        public IBiometricUnitsRepository BiometricUnitsRepository { get; }
        public IWeightUnitsRepository WeightUnitsRepository { get; }
        public IGrowthUnitsRepository GrowthUnitsRepository { get; }
        public ILiveWeightRepository LiveWeightRepository { get; set; }
        public IBreedingRepository BreedingRepository { get; set; }
        public IMilkYieldRepository MilkYieldRepository { get; set; }
        public IMilkYieldDetailRepository MilkYieldDetailRepository { get; set; }
        public IHealthRepository HealthRepository { get; set; }
        public ISemenRepository SemenRepository { get; set; }
        public IGenotypeRepository GenotypeRepository { get; set; }
        public IBreedingServiceRepository BreedingServiceRepository { get; set; }
        public IBreedingServiceDetailRepository BreedingServiceDetailRepository { get; set; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            DropdownRepository = new DropdownRepository(_dbContext);

            AnimalCategoryRepository = new AnimalCategoryRepository(_dbContext);
            AnimalRepository = new AnimalRepository(_dbContext);
            BiometricRepository = new BiometricRepository(_dbContext);
            BiometricUnitsRepository = new BiometricUnitsRepository(_dbContext);
            GrowthUnitsRepository = new GrowthUnitsRepository(_dbContext);
            WeightUnitsRepository = new WeightUnitsRepository(_dbContext);
            LiveWeightRepository =new LiveWeightRepository(_dbContext);
            BreedingRepository= new BreedingRepository(_dbContext);
            MilkYieldRepository = new MilkYieldRepository(_dbContext);
            HealthRepository = new HealthRepository(_dbContext);
            SemenRepository = new SemenRepository(_dbContext);
            GenotypeRepository = new GenotypeRepository(_dbContext);
            MilkYieldDetailRepository = new MilkYieldDetailRepository(_dbContext);
            BreedingServiceRepository = new BreedingServiceRepository(_dbContext);
            BreedingServiceDetailRepository =new BreedingServiceDetailRepository(_dbContext);
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