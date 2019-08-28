using BLRI.DAL.Interfaces.Core;
using BLRI.Entity.Task;
using BLRI.ViewModel.Health;
using System;
using System.Collections.Generic;

namespace BLRI.DAL.Interfaces.Task
{
    public interface IHealthRepository : IRepository<Health>
    {
        List<HealthViewModel> GetHealthByAnimalId(Guid animalId);
    }
}
