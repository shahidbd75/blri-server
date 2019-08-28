using System;
using System.Collections.Generic;
using System.Linq;
using BLRI.DAL.Interfaces.Task;
using BLRI.DAL.Repositories.Core;
using BLRI.Entity.Task;
using BLRI.ViewModel.Semen;

namespace BLRI.DAL.Repositories.Task
{
    public class SemenRepository : Repository<Semen>, ISemenRepository
    {
        public SemenRepository(ApplicationDbContext context) : base(context)
        {
        }


        public List<SemenViewModel> GetMilkYieldInfoByAnimalId(Guid animalId)
        {

            var milkYield = from s in Context.Semen
                join a in Context.Animal on s.AnimalId equals a.Id
                select new SemenViewModel()
                {
                    Id = s.Id,
                    AnimalId = s.AnimalId,
                    SpermMotility = s.SpermMotility,
                    SpermLivability = s.SpermLivability,
                    AgeAtFirstEjac = s.AgeAtFirstEjac,
                    SpermNormality = s.SpermNormality,
                    SemenVolume = s.SemenVolume,
                    NonReturnRate = s.NonReturnRate,
                    SemenConc = s.SemenConc,
                    ProgressiveSperm = s.ProgressiveSperm
                };
            return milkYield.ToList();
        }
    }
}
