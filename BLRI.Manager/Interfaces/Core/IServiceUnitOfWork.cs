using System.Threading.Tasks;
using BLRI.Manager.Interfaces.Animals;
using BLRI.Manager.Interfaces.LookUp;
using BLRI.Manager.Interfaces.Task;
using BLRI.Manager.Interfaces.Units;

namespace BLRI.Manager.Interfaces.Core
{
    public interface IServiceUnitOfWork
    {
        int Complete();
        Task<int> CompleteAsync();

        IAnimalCategoryManager AnimalCategoryManager{get;}
        IAnimalManager AnimalManager { get; }
        IBiometricManager BiometricManager { get; }
        IDropdownManager DropdownManager { get; set; }
        IBiometricUnitsManager BiometricUnitsManager { get; set; }
        IWeightUnitsManager WeightUnitsManager { get; set; }
        IGrowthUnitsManager GrowthUnitsManager { get; set; }
        IGrowthManager GrowthManager { get; set; }
        IBreedingManager BreedingManager { get; set; }
        IHealthManager HealthManager { get; set; }
        ILiveWeightManager LiveWeightManager { get; set; }
        IMilkYieldManager MilkYieldManager { get; set; }
        ISemenManager SemenManager { get; set; }
        IGenotypeManager GenotypeManager { get; set; }
    }
}