using System;
using System.Collections.Generic;
using System.Text;
using BLRI.Entity.Animals;
using BLRI.Entity.Base;

namespace BLRI.Entity
{
    public class Semen: BaseEntity
    {
        public double AgeAtFirstEjac { get; set; }
        public double SemenVolume { get; set; }
        public double SpermMotility { get; set; }
        public double SpermNormality { get; set; }
        public double NonReturnRate { get; set; }
        public double SemenConc { get; set; }
        public double ProgressiveSperm { get; set; }
        public double SpermLivability { get; set; }

        public Guid AnimalId { get; set; }
        public Animal Animal { get; set; }
    }
}
