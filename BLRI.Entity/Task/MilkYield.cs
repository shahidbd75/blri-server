using System;
using System.Collections.Generic;
using BLRI.Entity.Animals;
using BLRI.Entity.Base;

namespace BLRI.Entity.Task
{
    public class MilkYield: BaseEntity
    {
        public int CalvingParity { get; set; }
        public DateTime CalvingDate { get; set; }
        public DateTime FirstMilkDate { get; set; }
        public DateTime DryOff { get; set; }
        public DateTime NextCalving { get; set; }

        public Guid AnimalId { get; set; }
        public Animal Animal { get; set; }

        public ICollection<MilkYieldDetail> MilkYieldDetails { get; set; }
    }
}
