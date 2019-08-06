
using BLRI.Entity;
using BLRI.Entity.Animals;
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
        DbSet<Growth> Growth { get; set; }
        DbSet<Breeding> Breeding { get; set; }
        DbSet<Health> Health { get; set; }
        DbSet<Semen> Semen { get; set; }
        DbSet<MilkYield> MilkYield { get; set; }
        DbSet<Parentage> Parentage { get; set; }
    }
}
