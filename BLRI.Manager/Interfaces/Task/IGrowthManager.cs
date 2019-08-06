using System;
using System.Collections.Generic;
using BLRI.Manager.Interfaces.Core;
using BLRI.ViewModel.Growth;

namespace BLRI.Manager.Interfaces.Task
{
    public interface IGrowthManager : IBaseService<GrowthViewModel>
    {
        List<GrowthViewModel> GetGrowthByAnimalId(Guid animalId);
    }
}
