using System;
using System.Collections.Generic;
using BLRI.Manager.Interfaces.Core;
using BLRI.ViewModel.Health;

namespace BLRI.Manager.Interfaces.Task
{
    public interface IHealthManager: IBaseService<HealthViewModel>
    {
        List<HealthViewModel> GetHealthByAnimalId(Guid animalId);
    }
}
