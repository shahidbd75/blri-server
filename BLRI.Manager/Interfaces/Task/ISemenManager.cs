using System;
using System.Collections.Generic;
using BLRI.Manager.Interfaces.Core;
using BLRI.ViewModel.Semen;

namespace BLRI.Manager.Interfaces.Task
{
    public interface ISemenManager: IBaseService<SemenViewModel>
    {
        List<SemenViewModel> GetSemenByAnimalId(Guid animalId);
    }
}
