using System;
using System.Collections.Generic;
using System.Linq;
using BLRI.DAL.Interfaces.Task;
using BLRI.DAL.Repositories.Core;
using BLRI.Entity.Task;
using BLRI.ViewModel.BreedingServiceDetail;

namespace BLRI.DAL.Repositories.Task
{
    public class BreedingServiceDetailRepository : Repository<BreedingServiceDetail>, IBreedingServiceDetailRepository
    {
        public BreedingServiceDetailRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<BreedingServiceDetailViewModel> GetBreedingServiceDetailById(Guid serviceId)
        {
            var breedingServiceDetails = Context.BreedingServiceDetails.Where(bs => bs.BreedingServiceId == serviceId)
                .OrderByDescending(x => x.CreateDate).Select(s=> new BreedingServiceDetailViewModel
                {
                    BreedingServiceId = s.BreedingServiceId,
                    EstrousDate = s.EstrousDate,
                    ServiceConfirmed = s.ServiceConfirmed,
                    ServiceDate = s.ServiceDate,
                    Id = s.Id
                });
            return breedingServiceDetails.ToList();
        }
    }
}
