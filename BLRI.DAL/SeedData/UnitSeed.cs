using System;
using System.Collections.Generic;
using System.Text;
using BLRI.Entity.Units;

namespace BLRI.DAL.SeedData
{
    public static class UnitSeed
    {
        public static List<BiometricUnit> BiometricUnits =>
            new List<BiometricUnit>
            {
                new BiometricUnit {Id=1,Name = "A", Value = 0},
                new BiometricUnit {Id=2,Name = "B", Value = 0},
                new BiometricUnit {Id=3,Name = "V", Value = 0},
                new BiometricUnit {Id=4,Name = "D", Value = 0},
                new BiometricUnit {Id=5,Name = "C", Value = 0},
                new BiometricUnit {Id=6,Name = "E", Value = 0},
                new BiometricUnit {Id=7,Name = "F", Value = 0},
                new BiometricUnit {Id=8,Name = "G", Value = 0},
                new BiometricUnit {Id=9,Name = "H", Value = 0},
            };

        public static List<WeightUnit> WeightUnits =>
            new List<WeightUnit>
            {
                new WeightUnit {Id=1, Name = "Wei", Value = 0},
                new WeightUnit {Id=2, Name = "A2", Value = 0},
                new WeightUnit {Id=3, Name = "A34", Value = 0},
                new WeightUnit {Id=4, Name = "A5", Value = 0},
                new WeightUnit {Id=5, Name = "A6", Value = 0},
                new WeightUnit {Id=6, Name = "A7", Value = 0},
                new WeightUnit {Id=7, Name = "A88", Value = 0},
                new WeightUnit {Id=8, Name = "A8", Value = 0},
                new WeightUnit {Id=9, Name = "A9", Value = 0},
            };
        public static List<GrowthUnit> GrowthUnits =>
            new List<GrowthUnit>
            {
                new GrowthUnit {Id=1, Name = "Aas", Value = 0},
                new GrowthUnit {Id=2, Name = "Afs", Value = 0},
                new GrowthUnit {Id=3, Name = "Aal", Value = 0},
                new GrowthUnit {Id=4, Name = "Aqw", Value = 0},
                new GrowthUnit {Id=5, Name = "Aa", Value = 0},
                new GrowthUnit {Id=6, Name = "Ae", Value = 0},
                new GrowthUnit {Id=7, Name = "Aw", Value = 0},
                new GrowthUnit {Id=8, Name = "Aq", Value = 0},
                new GrowthUnit {Id=9, Name = "Aes", Value = 0},
            };
    }
}
