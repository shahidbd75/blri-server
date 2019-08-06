using System;
using System.Collections.Generic;
using System.Text;

namespace BLRI.ViewModel.Semen
{
    public class SemenViewModel
    {
        public Guid Id { get; set; }
        public double AgeAtFirstEjac { get; set; }
        public double SemenVolume { get; set; }
        public double SpermMotility { get; set; }
        public double SpermNormality { get; set; }
        public double NonReturnRate { get; set; }
        public double SemenConc { get; set; }
        public double ProgressiveSperm { get; set; }
        public double SpermLivability { get; set; }

        public Guid AnimalId { get; set; }
    }
}
