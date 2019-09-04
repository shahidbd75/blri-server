using System;
using System.Collections.Generic;
using System.Linq;
using BLRI.DAL.Interfaces.Task;
using BLRI.DAL.Repositories.Core;
using BLRI.Entity.Task;
using BLRI.ViewModel.Milk_Yield;

namespace BLRI.DAL.Repositories.Task
{
    public class MilkYieldDetailRepository : Repository<MilkYieldDetail>, IMilkYieldDetailRepository
    {
        public MilkYieldDetailRepository(ApplicationDbContext context) : base(context)
        {
        }


        public List<MilkYieldDetailViewModel> GetMilkYieldDetailById(Guid milkYieldId)
        {
            var milkYield = from my in Context.MilkYieldDetail
                            where my.MilkYieldId == milkYieldId
                select new MilkYieldDetailViewModel
                {
                    Id = my.Id,
                    MilkYieldId = my.MilkYieldId,
                    DailyMilkYield = my.DailyMilkYield,
                    Day = my.Day,
                    UpdatedByUserId = my.UpdatedByUserId
                };
            return milkYield.ToList();
        }
    }
}
