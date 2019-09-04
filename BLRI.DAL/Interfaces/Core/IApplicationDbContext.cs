using BLRI.Entity;
using BLRI.Entity.Animals;
using BLRI.Entity.Task;
using BLRI.Entity.Units;
using Microsoft.EntityFrameworkCore;

namespace BLRI.DAL.Interfaces.Core
{
    public interface IApplicationDbContext
    {
        DbSet<BiometricUnit> BiometricUnit { get; set; }
        DbSet<GrowthUnit> GrowthUnit { get; set; }
        DbSet<WeightUnit> WeightUnit { get; set; }
        DbSet<AnimalCategory> AnimalCategory { get; set; }

        DbSet<Genotype> Genotype { get; set; }
        DbSet<Animal> Animal { get; set; }
        DbSet<LiveWeight> LiveWeight { get; set; }
        DbSet<Biometric> Biometric { get; set; }
        DbSet<Breeding> Breeding { get; set; }
        DbSet<Health> Health { get; set; }
        DbSet<Semen> Semen { get; set; }
        DbSet<MilkYield> MilkYield { get; set; }
        DbSet<MilkYieldDetail> MilkYieldDetail { get; set; }

        DbSet<BreedingService> BreedingServices { get; set; }
        DbSet<BreedingServiceDetail> BreedingServiceDetails { get; set; }
    }
}
