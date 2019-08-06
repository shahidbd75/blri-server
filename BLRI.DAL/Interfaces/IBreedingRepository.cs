using BLRI.DAL.Interfaces.Core;
using BLRI.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using BLRI.ViewModel.Biometric;
using BLRI.ViewModel.Breeding;
using BLRI.ViewModel.Live_Weight;

namespace BLRI.DAL.Interfaces
{
    public interface IBreedingRepository: IRepository<Breeding>
    {
        List<BreedingViewModel> GetBreedingByAnimalId(Guid animalId);
    }
}
