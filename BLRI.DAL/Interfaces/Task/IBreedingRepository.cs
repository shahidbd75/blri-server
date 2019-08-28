using BLRI.DAL.Interfaces.Core;
using BLRI.Entity.Task;
using BLRI.ViewModel.Breeding;
using System;
using System.Collections.Generic;

namespace BLRI.DAL.Interfaces.Task
{
    public interface IBreedingRepository: IRepository<Breeding>
    {
        List<BreedingViewModel> GetBreedingByAnimalId(Guid animalId);
    }
}
