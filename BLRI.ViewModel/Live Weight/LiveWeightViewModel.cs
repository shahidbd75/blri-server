using System;
using BLRI.ViewModel.Core;

namespace BLRI.ViewModel.Live_Weight
{
    public class LiveWeightViewModel: BaseViewModel<Guid>
    {
        public string WeightValue { get; set; }
        public Guid AnimalId { get; set; }
        public long WeightUnitId { get; set; }
        public string WeightUnitName { get; set; }
        public int CategoryId { get; set; }
    }
}
