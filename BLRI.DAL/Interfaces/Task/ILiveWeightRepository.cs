using BLRI.DAL.Interfaces.Core;
using BLRI.Entity.Task;
using BLRI.ViewModel.Live_Weight;
using System;
using System.Collections.Generic;

namespace BLRI.DAL.Interfaces.Task
{
    public interface ILiveWeightRepository: IRepository<LiveWeight>
    {
        List<LiveWeightViewModel> GetLiveWeightByAnimalId(Guid animalId);
        LiveWeightViewModel GetLiveWeightById(Guid id);
    }
}
