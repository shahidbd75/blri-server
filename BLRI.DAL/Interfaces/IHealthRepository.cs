using BLRI.DAL.Interfaces.Core;
using BLRI.Entity;
using System;
using System.Collections.Generic;
using BLRI.ViewModel.Health;


namespace BLRI.DAL.Interfaces
{
    public interface IHealthRepository : IRepository<Health>
    {
        List<HealthViewModel> GetHealthByAnimalId(Guid animalId);
    }
}
