﻿using System;
using System.Collections.Generic;
using System.Text;
using BLRI.Entity.Animals;
using BLRI.Entity.Base;

namespace BLRI.Entity
{
    public class MilkYield: BaseEntity
    {
        public double LactationLength { get; set; }
        public double LactationMilkYield { get; set; }
        public double DailyMilkYield { get; set; }
        public double Persistency { get; set; }
        public double DryPeriod { get; set; }

        public Guid AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
