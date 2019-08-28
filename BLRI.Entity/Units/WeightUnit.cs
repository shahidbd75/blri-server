using System.Collections.Generic;
using BLRI.Entity.Base;
using BLRI.Entity.Task;

namespace BLRI.Entity.Units
{
    public class WeightUnit: BaseUnit
    {
        public ICollection<LiveWeight> LiveWeights { get; set; }
    }
}
