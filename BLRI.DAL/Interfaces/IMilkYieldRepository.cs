﻿using BLRI.DAL.Interfaces.Core;
using BLRI.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using BLRI.ViewModel.Biometric;
using BLRI.ViewModel.Live_Weight;
using BLRI.ViewModel.Milk_Yield;

namespace BLRI.DAL.Interfaces
{
    public interface IMilkYieldRepository : IRepository<MilkYield>
    {
        List<MilkYieldViewModel> GetMilkYieldInfoByAnimalId(Guid animalId);
    }
}