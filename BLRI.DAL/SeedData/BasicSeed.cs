using System;
using System.Collections.Generic;
using System.Text;
using BLRI.Entity.Animals;

namespace BLRI.DAL.SeedData
{
    public static class BasicSeed
    {
        public static List<AnimalCategory> AnimalCategories =>
            new List<AnimalCategory>
            {
                new AnimalCategory {Id = 1, Name = "Buffalo"},
                new AnimalCategory {Id = 2, Name = "Cattle"}
            };
        public static List<Genotype> Genotypes =>
            new List<Genotype>
            {
                new Genotype {Id = 1, Name = "RCC"},
                new Genotype {Id = 2, Name = "MC"},
                new Genotype {Id = 3, Name = "BCB-1"}
            };
    }
}
