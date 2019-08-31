using System;
using BLRI.ViewModel.Core;

namespace BLRI.ViewModel.Milk_Yield
{
    public class MilkYieldViewModel: BaseViewModel<Guid>
    {
        public int CalvingParity { get; set; }
        public DateTime CalvingDate { get; set; }
        public DateTime FirstMilkDate { get; set; }
        public DateTime DryOff { get; set; }
        public DateTime NextCalving { get; set; }
        public Guid AnimalId { get; set; }
    }
}
