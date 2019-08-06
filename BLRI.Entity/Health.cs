using System;
using System.Collections.Generic;
using System.Text;
using BLRI.Entity.Animals;
using BLRI.Entity.Base;

namespace BLRI.Entity
{
    public class Health: BaseEntity
    {
        public double Vaccination { get; set; }
        public double DeWorming { get; set; }
        public double Disease { get; set; }
        public double Parasite { get; set; }
        public double Treatment { get; set; }
        public Guid AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
