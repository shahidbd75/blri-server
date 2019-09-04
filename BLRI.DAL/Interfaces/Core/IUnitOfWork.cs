using System;
using System.Threading.Tasks;
using BLRI.DAL.Interfaces.Animals;
using BLRI.DAL.Interfaces.LookUp;
using BLRI.DAL.Interfaces.Task;
using BLRI.DAL.Interfaces.Units;

namespace BLRI.DAL.Interfaces.Core
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
        Task<int> CompleteAsync();

        IAnimalCategoryRepository AnimalCategoryRepository { get; }
        IDropdownRepository DropdownRepository { get; }
        IAnimalRepository AnimalRepository { get; }
        IBiometricRepository BiometricRepository{ get; }
        IBiometricUnitsRepository BiometricUnitsRepository { get; }
        IWeightUnitsRepository WeightUnitsRepository { get; }
        IGrowthUnitsRepository GrowthUnitsRepository { get; }
        ILiveWeightRepository LiveWeightRepository { get; set; }
        IBreedingRepository BreedingRepository { get; set; }
        IMilkYieldRepository MilkYieldRepository { get; set; }
        IMilkYieldDetailRepository MilkYieldDetailRepository { get; set; }
        IHealthRepository HealthRepository { get; set; }
        ISemenRepository SemenRepository { get; set; }
        IGenotypeRepository GenotypeRepository { get; set; }
    }
}