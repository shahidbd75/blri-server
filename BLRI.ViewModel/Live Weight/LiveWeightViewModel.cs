using System;
using System.Collections.Generic;
using System.Text;

namespace BLRI.ViewModel.Live_Weight
{
    public class LiveWeightViewModel
    {
        public Guid Id { get; set; }
        public string WeightValue { get; set; }
        public Guid AnimalId { get; set; }
        public long WeightUnitId { get; set; }
        public string WeightUnitName { get; set; }
        public int CategoryId { get; set; }
    }
}
