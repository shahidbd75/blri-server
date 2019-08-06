using BLRI.DAL.Interfaces;
using BLRI.DAL.Repositories.Core;
using BLRI.Entity;
using BLRI.ViewModel.Breeding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLRI.DAL.Repositories
{
    public class BreedingRepository : Repository<Breeding>, IBreedingRepository
    {
        public BreedingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<BreedingViewModel> GetBreedingByAnimalId(Guid animalId)
        {
            var breeding = from b in Context.Breeding
                join a in Context.Animal on b.AnimalId equals a.Id
                select new BreedingViewModel
                {
                    Id = b.Id,
                    AnimalId = b.AnimalId,
                    WeaningDate = b.WeaningDate,
                    FirstCalvingDate = b.FirstCalvingDate,
                    FirstConceptionDate = b.FirstConceptionDate,
                    FirstHeatDate = b.FirstHeatDate
                };
            return breeding.ToList();
        }
    }
}
