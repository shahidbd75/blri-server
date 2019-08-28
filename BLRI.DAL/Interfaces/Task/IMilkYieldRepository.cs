using System;
using System.Collections.Generic;
using BLRI.DAL.Interfaces.Core;
using BLRI.Entity.Task;
using BLRI.ViewModel.Milk_Yield;

namespace BLRI.DAL.Interfaces.Task
{
    public interface IMilkYieldRepository : IRepository<MilkYield>
    {
        List<MilkYieldViewModel> GetMilkYieldInfoByAnimalId(Guid animalId);
    }
}
