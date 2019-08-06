using System;
using System.Collections.Generic;
using System.Text;

namespace BLRI.ViewModel.Animals
{
    public class AnimalListViewModel: AnimalViewModel
    {
        public string CategoryName { get; set; }
        public string GenotypeName { get; set; }
        public string GenderName { get; set; }
        public string DamAIdNew { get; set; }
        public string SireAIdNew { get; set; }
    }
}
