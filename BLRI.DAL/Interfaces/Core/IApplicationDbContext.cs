
using BLRI.Entity;
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
    }
}
