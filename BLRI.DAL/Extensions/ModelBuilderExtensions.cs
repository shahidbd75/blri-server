using System.Text;
using BLRI.DAL.SeedData;
using BLRI.Entity.Animals;
using BLRI.Entity.Units;
using Microsoft.EntityFrameworkCore;

namespace BLRI.DAL.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BiometricUnit>().HasData(UnitSeed.BiometricUnits);
            modelBuilder.Entity<GrowthUnit>().HasData(UnitSeed.GrowthUnits);
            modelBuilder.Entity<WeightUnit>().HasData(UnitSeed.WeightUnits);
            modelBuilder.Entity<Genotype>().HasData(BasicSeed.Genotypes);
            modelBuilder.Entity<AnimalCategory>().HasData(BasicSeed.AnimalCategories);
        }
    }
}
