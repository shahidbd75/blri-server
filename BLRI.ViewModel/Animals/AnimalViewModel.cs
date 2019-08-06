using System;
using System.Collections.Generic;
using System.Text;
using BLRI.Entity.Animals;
using BLRI.ViewModel.Core;

namespace BLRI.ViewModel.Animals
{
    public class AnimalViewModel: BaseViewModel<Guid>
    {
        public string AIdNew { get; set; }
        public string AIdOld { get; set; }
        public int CategoryId { get; set; }
        public DateTime BirthDate { get; set; }

        public Gender Gender { get; set; }

        public Guid? SireId { get; set; }
        public Guid? DamId { get; set; }

        public int GenotypeId { get; set; }

        public int Generation { get; set; }
        public int DamParity { get; set; }

        public string BirthSession { get; set; }
        public int Year { get; set; }
    }
}
