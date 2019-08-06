using System.Collections.Generic;
using BLRI.Entity.Base;

namespace BLRI.Entity.Units
{
    public class WeightUnit: BaseUnit
    {
        public ICollection<LiveWeight> LiveWeights { get; set; }
    }
}
