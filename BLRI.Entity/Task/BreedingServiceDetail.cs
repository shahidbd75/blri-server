using System;
using System.Collections.Generic;
using System.Text;
using BLRI.Entity.Base;

namespace BLRI.Entity.Task
{
    public class BreedingServiceDetail: BaseEntity
    {
        public Guid BreedingServiceId { get; set; }
        public DateTime EstrousDate { get; set; }
        public DateTime ServiceDate { get; set; }
        public Boolean ServiceConfirmed { get; set; }

        public BreedingService BreedingService { get; set; }
    }
}
