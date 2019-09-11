using BLRI.DAL.Interfaces.Core;
using BLRI.Entity.Task;
using BLRI.ViewModel.Breeding;
using System;
using System.Collections.Generic;
using BLRI.ViewModel.BreedingService;

namespace BLRI.DAL.Interfaces.Task
{
    public interface IBreedingServiceRepository: IRepository<BreedingService>
    {
        List<BreedingServiceViewModel> GetBreedingServiceByAnimalId(Guid animalId);

        bool IsExistBreedingServiceByParity(Guid animalId, int parity);

        bool IsExistBreedingServiceByParityOther(Guid id, Guid animalId, int parity);
    }
}
