using System;
using System.Collections.Generic;
using System.Text;
using BLRI.Entity.Base;

namespace BLRI.Entity.Task
{
    public class MilkYieldDetail: BaseEntity
    {
        public Guid MilkYieldId { get; set; }
        public int Day { get; set; }
        public double DailyMilkYield { get; set; }

        public MilkYield MilkYield { get; set; }
    }
}
