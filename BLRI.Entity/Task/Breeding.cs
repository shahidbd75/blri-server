using System;
using BLRI.Entity.Animals;
using BLRI.Entity.Base;

namespace BLRI.Entity.Task
{
    public class Breeding: BaseEntity
    {
        public Guid AnimalId { get; set; }
        public DateTime WeaningDate { get; set; }
        public DateTime FirstHeatDate { get; set; }
        public DateTime FirstConceptionDate{ get; set; }
        public DateTime FirstCalvingDate { get; set; }
        public Animal Animal { get; set; }
    }
}
