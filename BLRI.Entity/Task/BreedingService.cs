using System;
using System.Collections.Generic;
using BLRI.Entity.Animals;
using BLRI.Entity.Base;

namespace BLRI.Entity.Task
{
    public class BreedingService: BaseEntity
    {
        public Guid AnimalId { get; set; }
        public int Parity { get; set; }
        public DateTime CalvingDate { get; set; }

        public Animal Animal { get; set; }

        public ICollection<BreedingServiceDetail> BreedingServiceDetails { get; set; }
    }
}
