using System;
using BLRI.Entity.Animals;
using BLRI.Entity.Base;
using BLRI.Entity.Units;

namespace BLRI.Entity.Task
{
    public class LiveWeight: BaseEntity
    {
        public string WeightValue { get; set; }
        public Guid AnimalId { get; set; }
        public long WeightUnitId { get; set; }
        public WeightUnit WeightUnit { get; set; }
        public Animal Animal { get; set; }

    }
}
