using BLRI.DAL.Interfaces.Core;
using BLRI.Entity;
using System;
using System.Collections.Generic;

using BLRI.ViewModel.Growth;

namespace BLRI.DAL.Interfaces
{
    public interface IGrowthRepository : IRepository<Growth>
    {
        List<GrowthViewModel> GetGrowthInfoByAnimalId(Guid animalId);
    }
}
