using System;
using System.Collections.Generic;
using System.Text;

namespace BLRI.ViewModel.Health
{
    public class HealthViewModel
    {
        public Guid Id { get; set; }
        public double Vaccination { get; set; }
        public double DeWorming { get; set; }
        public double Disease { get; set; }
        public double Parasite { get; set; }
        public double Treatment { get; set; }
        public Guid AnimalId { get; set; }
    }
}
