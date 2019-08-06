using BLRI.DAL.Interfaces.Core;
using BLRI.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using BLRI.ViewModel.Biometric;
using BLRI.ViewModel.Live_Weight;

namespace BLRI.DAL.Interfaces
{
    public interface ILiveWeightRepository: IRepository<LiveWeight>
    {
        List<LiveWeightViewModel> GetLiveWeightByAnimalId(Guid animalId);
        LiveWeightViewModel GetLiveWeightById(Guid id);
    }
}
