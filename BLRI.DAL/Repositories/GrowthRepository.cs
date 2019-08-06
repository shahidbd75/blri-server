using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLRI.DAL.Interfaces;
using BLRI.DAL.Repositories.Core;
using BLRI.Entity;
using BLRI.ViewModel.Biometric;
using BLRI.ViewModel.Growth;
using BLRI.ViewModel.Health;

namespace BLRI.DAL.Repositories
{
    public class GrowthRepository : Repository<Growth>, IGrowthRepository
    {
        public GrowthRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<GrowthViewModel> GetGrowthInfoByAnimalId(Guid animalId)
        {
            var growth = from g in Context.Growth
                join gu in Context.GrowthUnit on g.GrowthUnitId equals  gu.Id
                join a in Context.Animal on g.AnimalId equals a.Id
                where g.AnimalId == animalId
                select new GrowthViewModel()
                {
                    Id = g.Id,
                    AnimalId = g.AnimalId,
                    GrowthUnitId = g.GrowthUnitId,
                    GrowthValue = g.GrowthValue,
                    GrowthUnitName = gu.Name
                };
            return growth.ToList();
        }
    }
}
