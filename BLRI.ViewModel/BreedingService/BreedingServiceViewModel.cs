using System;
using System.ComponentModel.DataAnnotations;
using BLRI.ViewModel.Core;

namespace BLRI.ViewModel.BreedingService
{
    public class BreedingServiceViewModel: BaseViewModel<Guid>
    {
        [Required]
        public Guid AnimalId { get; set; }
        [Required]
        public int Parity { get; set; }
        public DateTime CalvingDate { get; set; }

        public string AnimalIdNew { get; set; }
    }
}
