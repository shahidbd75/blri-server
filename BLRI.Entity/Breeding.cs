using System;
using System.Collections.Generic;
using System.Text;
using BLRI.Entity.Animals;
using BLRI.Entity.Base;

namespace BLRI.Entity
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
