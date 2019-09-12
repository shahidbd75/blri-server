using System;
using BLRI.ViewModel.Core;

namespace BLRI.ViewModel.BreedingServiceDetail
{
    public class BreedingServiceDetailViewModel: BaseViewModel<Guid>
    {
        public Guid BreedingServiceId { get; set; }
        public DateTime EstrousDate { get; set; }
        public DateTime ServiceDate { get; set; }
        public Boolean ServiceConfirmed { get; set; }
    }
}
