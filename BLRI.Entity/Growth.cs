using System;
using System.Collections.Generic;
using System.Text;
using BLRI.Entity.Animals;
using BLRI.Entity.Base;
using BLRI.Entity.Units;
using Microsoft.EntityFrameworkCore.Design;

namespace BLRI.Entity
{
    public class Growth :  BaseEntity
    {
        public Guid AnimalId { get; set; }
        public long GrowthUnitId { get; set; }

        public double GrowthValue { get; set; }        
        public GrowthUnit GrowthUnit { get; set; }
        public Animal Animal { get; set; }
    }
}
