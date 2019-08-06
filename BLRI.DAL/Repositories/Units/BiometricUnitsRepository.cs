using System;
using System.Collections.Generic;
using System.Text;
using BLRI.DAL.Interfaces.Units;
using BLRI.DAL.Repositories.Core;
using BLRI.Entity.Units;

namespace BLRI.DAL.Repositories.Units
{
    public class BiometricUnitsRepository : Repository<BiometricUnit>, IBiometricUnitsRepository
    {
        public BiometricUnitsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
