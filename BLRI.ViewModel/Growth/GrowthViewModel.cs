using System;
using System.Collections.Generic;
using System.Text;

namespace BLRI.ViewModel.Growth
{
    public class GrowthViewModel
    {
        public Guid Id { get; set; }
        public Guid AnimalId { get; set; }
        public long GrowthUnitId { get; set; }
        public string GrowthUnitName { get; set; }
        public double GrowthValue { get; set; }
    }
}
