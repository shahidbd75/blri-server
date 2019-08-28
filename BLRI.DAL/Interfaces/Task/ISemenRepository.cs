using System;
using System.Collections.Generic;
using BLRI.DAL.Interfaces.Core;
using BLRI.Entity.Task;
using BLRI.ViewModel.Semen;

namespace BLRI.DAL.Interfaces.Task
{
    public interface ISemenRepository : IRepository<Semen>
    {
        List<SemenViewModel> GetMilkYieldInfoByAnimalId(Guid animalId);
    }
}
