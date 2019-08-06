using System;
using System.Collections.Generic;
using System.Text;

namespace BLRI.ViewModel.Breeding
{
    public class BreedingViewModel
    {
        public Guid Id { get; set; }
        public Guid AnimalId { get; set; }
        public DateTime WeaningDate { get; set; }
        public DateTime FirstHeatDate { get; set; }
        public DateTime FirstConceptionDate { get; set; }
        public DateTime FirstCalvingDate { get; set; }
    }
}
