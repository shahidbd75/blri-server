using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Transactions;
using BLRI.DAL.Interfaces;
using BLRI.DAL.Repositories.Core;
using BLRI.Entity;
using BLRI.ViewModel.Biometric;
using BLRI.ViewModel.Live_Weight;

namespace BLRI.DAL.Repositories
{
    public class LiveWeightRepository : Repository<LiveWeight>, ILiveWeightRepository
    {
        public LiveWeightRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<LiveWeightViewModel> GetLiveWeightByAnimalId(Guid animalId)
        {
            var liveWeights = from lw in Context.LiveWeight
                join lu in Context.WeightUnit on lw.WeightUnitId equals  lu.Id
                join a in Context.Animal on lw.AnimalId equals a.Id
                where lw.AnimalId == animalId
                select new LiveWeightViewModel()
                {
                    Id = lw.Id,
                    AnimalId = lw.AnimalId,
                    WeightValue = lw.WeightValue,
                    WeightUnitId = lw.WeightUnitId,
                    WeightUnitName = lu.Name
                };
            return liveWeights.ToList();
        }

        public LiveWeightViewModel GetLiveWeightById(Guid id)
        {
            var liveWeight = from weight in Context.LiveWeight
                join anim in Context.Animal on weight.AnimalId equals anim.Id
                select new LiveWeightViewModel
                {
                    AnimalId = weight.AnimalId,
                    CategoryId = anim.CategoryId,
                    Id = weight.Id,
                    WeightValue = weight.WeightValue,
                    WeightUnitId = weight.WeightUnitId
                };
            return liveWeight.FirstOrDefault();
        }
    }
}
