using System;
using System.Collections.Generic;
using System.Text;
using BLRI.DAL.Interfaces.Units;
using BLRI.DAL.Repositories.Core;
using BLRI.Entity.Units;

namespace BLRI.DAL.Repositories.Units
{
    public class WeightUnitsRepository : Repository<WeightUnit>, IWeightUnitsRepository
    {
        public WeightUnitsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
