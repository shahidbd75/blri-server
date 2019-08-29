using System;
using BLRI.ViewModel.Core;

namespace BLRI.ViewModel.Growth
{
    public class GrowthViewModel: BaseViewModel<Guid>
    {
        public Guid AnimalId { get; set; }
        public long GrowthUnitId { get; set; }
        public string GrowthUnitName { get; set; }
        public double GrowthValue { get; set; }
    }
}
