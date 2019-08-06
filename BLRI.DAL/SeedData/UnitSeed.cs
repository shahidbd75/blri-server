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
                new BiometricUnit {Id=1,Name = "Birth", Value = 0},
                new BiometricUnit {Id=2,Name = "3 Month", Value = 0},
                new BiometricUnit {Id=3,Name = "6 Month", Value = 0},
                new BiometricUnit {Id=4,Name = "Wean", Value = 0},
                new BiometricUnit {Id=5,Name = "9 Month", Value = 0},
                new BiometricUnit {Id=6,Name = "12 Month", Value = 0},
                new BiometricUnit {Id=7,Name = "18 Month", Value = 0},
                new BiometricUnit {Id=8,Name = "24 Month", Value = 0},
                new BiometricUnit {Id=9,Name = "Puberty", Value = 0},
                new BiometricUnit {Id=10,Name = "30 Month", Value = 0},
                new BiometricUnit {Id=11,Name = "36 Month", Value = 0}
            };

        public static List<WeightUnit> WeightUnits =>
            new List<WeightUnit>
            {
                new WeightUnit {Id=1, Name = "Birth", Value = 0},
                new WeightUnit {Id=2, Name = "3 month", Value = 0},
                new WeightUnit {Id=3, Name = "6 Month", Value = 0},
                new WeightUnit {Id=4, Name = "Wean", Value = 0},
                new WeightUnit {Id=5, Name = "9 Month", Value = 0},
                new WeightUnit {Id=6, Name = "Yearly", Value = 0},
                new WeightUnit {Id=7, Name = "18 Month", Value = 0},
                new WeightUnit {Id=8, Name = "24 Month", Value = 0},
                new WeightUnit {Id=9, Name = "Puberty", Value = 0},
                new WeightUnit {Id=10, Name = "30 Month", Value = 0},
                new WeightUnit {Id=11, Name = "36 Month", Value = 0},
            };
        public static List<GrowthUnit> GrowthUnits =>
            new List<GrowthUnit>
            {
                new GrowthUnit {Id=1, Name = "Birth", Value = 0},
                new GrowthUnit {Id=2, Name = "3 Month", Value = 0},
                new GrowthUnit {Id=3, Name = "6 Month", Value = 0},
                new GrowthUnit {Id=4, Name = "9 Month", Value = 0},
                new GrowthUnit {Id=5, Name = "12 Month", Value = 0},
                new GrowthUnit {Id=6, Name = "18 Month", Value = 0},
                new GrowthUnit {Id=7, Name = "24 Month", Value = 0},
                new GrowthUnit {Id=8, Name = "30 Month", Value = 0},
                new GrowthUnit {Id=9, Name = "Puberty", Value = 0},
                new GrowthUnit {Id=10, Name = "36 Month", Value = 0},
                new GrowthUnit {Id=11, Name = "Puberty", Value = 0}
            };
    }
}
