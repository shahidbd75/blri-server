using System;
using System.Collections.Generic;
using System.Linq;
using BLRI.DAL.Interfaces.Task;
using BLRI.DAL.Repositories.Core;
using BLRI.Entity.Task;
using BLRI.ViewModel.Milk_Yield;

namespace BLRI.DAL.Repositories.Task
{
    public class MilkYieldRepository : Repository<MilkYield>, IMilkYieldRepository
    {
        public MilkYieldRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<MilkYieldViewModel> GetMilkYieldInfoByAnimalId(Guid animalId)
        {
            var milkYield = from my in Context.MilkYield
                join a in Context.Animal on my.AnimalId equals a.Id
                select new MilkYieldViewModel()
                {
                    Id = my.Id,
                    AnimalId = my.AnimalId,
                    CalvingParity = my.CalvingParity,
                    CalvingDate = my.CalvingDate,
                    FirstMilkDate = my.FirstMilkDate,
                    NextCalving = my.NextCalving,
                    DryOff = my.DryOff
                };
            return milkYield.ToList();
        }
    }
}
