using System;
using BLRI.ViewModel.Core;

namespace BLRI.ViewModel.Breeding
{
    public class BreedingViewModel: BaseViewModel<Guid>
    {
        public Guid AnimalId { get; set; }
        public DateTime? WeaningDate { get; set; }
        public DateTime? FirstHeatDate { get; set; }
        public DateTime? FirstConceptionDate { get; set; }
        public DateTime? FirstCalvingDate { get; set; }
    }
}
