using System;
using System.Collections.Generic;
using BLRI.Manager.Interfaces.Core;
using BLRI.ViewModel.BreedingService;

namespace BLRI.Manager.Interfaces.Task
{
    public interface IBreedingServiceManager: IBaseService<BreedingServiceViewModel>
    {
        List<BreedingServiceViewModel> GetBreedingServiceByAnimalId(Guid animalId);

        bool IsExistBreedingServiceByParity(Guid animalId, int parity);

        bool IsExistBreedingServiceByParityOther(Guid id, Guid animalId, int parity);
    }
}
