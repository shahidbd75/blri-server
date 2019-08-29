using System;
using BLRI.ViewModel.Core;

namespace BLRI.ViewModel.Health
{
    public class HealthViewModel: BaseViewModel<Guid>
    {
        public double Vaccination { get; set; }
        public double DeWorming { get; set; }
        public double Disease { get; set; }
        public double Parasite { get; set; }
        public double Treatment { get; set; }
        public Guid AnimalId { get; set; }
    }
}
