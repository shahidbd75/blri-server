using System;
using System.Collections.Generic;
using System.Text;

namespace BLRI.ViewModel.BreedingService
{
    public class BreedingServiceListViewModel: BreedingServiceViewModel
    {
        public int  FrequencyOfService { get; set; }
        public bool ServiceConfirmed { get; set; }
    }
}
