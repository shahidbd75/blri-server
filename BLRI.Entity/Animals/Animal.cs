using System;
using System.Collections.Generic;
using BLRI.Entity.Base;

namespace BLRI.Entity.Animals
{
    public class Animal: BaseEntity
    {
        public string AIdNew { get; set; }
        public string AIdOld { get; set; }
        public int CategoryId { get; set; }
        public DateTime BirthDate { get; set; }

        public Gender  Gender{ get; set; }

        public Guid? SireId { get; set; }
        public Guid? DamId { get; set; }

        public int GenotypeId { get; set; }

        public int Generation { get; set; }
        public int DamParity { get; set; }

        public string BirthSession { get; set; }
        public int Year { get; set; }


        #region Foreign Key

        public Genotype Genotype { get; set; }
        public ICollection<Animal> DamAnimals { get; set; }
        public ICollection<Animal> SireAnimals { get; set; }
        public Animal Dam { get; set; }
        public Animal Sire { get; set; }

        public AnimalCategory AnimalCategory { get; set; }

        public ICollection<Biometric> Biometrics { get; set; }
        public ICollection<LiveWeight> LiveWeights { get; set; }
        public ICollection<Growth> Growths { get; set; }
        public ICollection<Health> Healths { get; set; }
        public ICollection<Semen> Semens { get; set; }
        public ICollection<Breeding> Breedings { get; set; }
        public ICollection<Parentage> Parentages { get; set; }
        public ICollection<MilkYield> MilkYields { get; set; }
        #endregion

    }
}
