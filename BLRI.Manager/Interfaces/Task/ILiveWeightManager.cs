using System;
using System.Collections.Generic;
using BLRI.Manager.Interfaces.Core;
using BLRI.ViewModel.Live_Weight;

namespace BLRI.Manager.Interfaces.Task
{
    public interface ILiveWeightManager : IBaseService<LiveWeightViewModel>
    {
        List<LiveWeightViewModel> GetLiveWeightByAnimalId(Guid animalId);
        LiveWeightViewModel GetLiveWeightById(Guid id);
    }
}
