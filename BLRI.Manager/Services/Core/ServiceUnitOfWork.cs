using System.Threading.Tasks;
using BLRI.DAL.Interfaces.Core;
using BLRI.Manager.Interfaces;
using BLRI.Manager.Interfaces.Animals;
using BLRI.Manager.Interfaces.Core;
using BLRI.Manager.Interfaces.LookUp;
using BLRI.Manager.Interfaces.Task;
using BLRI.Manager.Interfaces.Units;
using BLRI.Manager.Services.Animals;
using BLRI.Manager.Services.LookUp;
using BLRI.Manager.Services.Task;
using BLRI.Manager.Services.Units;

namespace BLRI.Manager.Services.Core
{
    public class ServiceUnitOfWork : IServiceUnitOfWork
    {
        protected readonly IUnitOfWork UnitOfWork;    

        public ServiceUnitOfWork(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            AnimalCategoryManager = new AnimalCategoryManager(unitOfWork);
            AnimalManager = new AnimalManager(unitOfWork);
            DropdownManager = new DropdownManager(unitOfWork);
            BiometricManager = new BiometricManager(unitOfWork);
            BiometricUnitsManager = new BiometricUnitsManager(unitOfWork);
            WeightUnitsManager = new WeightUnitsManager(unitOfWork);
            GrowthUnitsManager = new GrowthUnitsManager(unitOfWork);
            SemenManager = new SemenManager(unitOfWork);
            BreedingManager = new BreedingManager(unitOfWork);
            LiveWeightManager = new LiveWeightManager(unitOfWork);
            GrowthManager  = new GrowthManager(unitOfWork);
            HealthManager = new HealthManager(unitOfWork);
            MilkYieldManager =new MilkYieldManager(unitOfWork);
            GenotypeManager =new GenotypeManager(unitOfWork);
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
        public IAnimalManager AnimalManager { get; }
        public IBiometricManager BiometricManager { get; }
        public IDropdownManager DropdownManager { get; set; }
        public IBiometricUnitsManager BiometricUnitsManager { get; set; }
        public IWeightUnitsManager WeightUnitsManager { get; set; }
        public IGrowthUnitsManager GrowthUnitsManager { get; set; }
        public IGrowthManager GrowthManager { get; set; }
        public IBreedingManager BreedingManager { get; set; }
        public IHealthManager HealthManager { get; set; }
        public ILiveWeightManager LiveWeightManager { get; set; }
        public IMilkYieldManager MilkYieldManager { get; set; }
        public ISemenManager SemenManager { get; set; }
        public IGenotypeManager GenotypeManager { get; set; }
    }
}
