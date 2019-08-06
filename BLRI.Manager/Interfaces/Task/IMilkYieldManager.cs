using System;
using System.Collections.Generic;
using BLRI.Manager.Interfaces.Core;
using BLRI.ViewModel.Milk_Yield;

namespace BLRI.Manager.Interfaces.Task
{
    public interface IMilkYieldManager : IBaseService<MilkYieldViewModel>
    {
        List<MilkYieldViewModel> GetMilkYieldByAnimalId(Guid animalId);
    }
}
