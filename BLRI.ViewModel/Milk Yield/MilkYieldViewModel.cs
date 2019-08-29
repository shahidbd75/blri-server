﻿using System;
using BLRI.ViewModel.Core;

namespace BLRI.ViewModel.Milk_Yield
{
    public class MilkYieldViewModel: BaseViewModel<Guid>
    {
        public double LactationLength { get; set; }
        public double LactationMilkYield { get; set; }
        public double DailyMilkYield { get; set; }
        public double Persistency { get; set; }
        public double DryPeriod { get; set; }
        public Guid AnimalId { get; set; }
    }
}
