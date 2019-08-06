using System;
using System.Collections.Generic;
using System.Text;
using BLRI.Entity.Base;

namespace BLRI.Entity.Units
{
    public class GrowthUnit : BaseUnit
    {
        public ICollection<Growth> Growths { get; set; }
    }
}
