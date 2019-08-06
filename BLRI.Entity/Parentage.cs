using System;
using System.Collections.Generic;
using System.Text;
using BLRI.Entity.Animals;
using BLRI.Entity.Base;

namespace BLRI.Entity
{
    public class Parentage: BaseEntity
    {
        public Guid AnimalId { get; set; }

        public Guid PatGrandDam { get; set; }
        public Guid MatGrandDam { get; set; }
        public Guid PaternalAunt { get; set; }
        public Guid MaternalAunt{ get; set; }
        public Guid FullSibBro{ get; set; }
        public Guid FullSibSis{ get; set; }
        public Guid HalfSibBro{ get; set; }
        public Guid HalfSibSis{ get; set; }

        public Animal Animal { get; set; }
    }
}
