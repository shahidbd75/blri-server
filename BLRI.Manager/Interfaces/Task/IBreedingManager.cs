using System;
using System.Collections.Generic;
using BLRI.Manager.Interfaces.Core;
using BLRI.ViewModel.Breeding;

namespace BLRI.Manager.Interfaces.Task
{
    public interface IBreedingManager: IBaseService<BreedingViewModel>
    {
        List<BreedingViewModel> GetBreedingByAnimalId(Guid animalId);
    }
}
