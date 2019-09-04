using System;
using BLRI.ViewModel.Core;

namespace BLRI.ViewModel.Milk_Yield
{
    public class MilkYieldDetailViewModel: BaseViewModel<Guid>
    {
        public Guid MilkYieldId { get; set; }
        public int Day { get; set; }
        public double DailyMilkYield { get; set; }
    }
}
