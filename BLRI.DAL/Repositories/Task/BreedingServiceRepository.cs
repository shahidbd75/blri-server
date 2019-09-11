using System;
using System.Collections.Generic;
using System.Linq;
using BLRI.DAL.Interfaces.Task;
using BLRI.DAL.Repositories.Core;
using BLRI.Entity.Task;
using BLRI.ViewModel.BreedingService;

namespace BLRI.DAL.Repositories.Task
{
    public class BreedingServiceRepository : Repository<BreedingService>, IBreedingServiceRepository
    {
        public BreedingServiceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<BreedingServiceViewModel> GetBreedingServiceByAnimalId(Guid animalId)
        {
            var breedingService = from b in Context.BreedingServices
                join a in Context.Animal on b.AnimalId equals a.Id
                select new BreedingServiceViewModel
                {
                    Id = b.Id,
                    AnimalId = b.AnimalId,
                    CalvingDate = b.CalvingDate,
                    Parity = b.Parity
                };
            return breedingService.ToList();
        }

        public bool IsExistBreedingServiceByParity(Guid animalId, int parity)
        {
            return Context.BreedingServices.Any(bs => bs.AnimalId == animalId && bs.Parity == parity);
        }

        public bool IsExistBreedingServiceByParityOther(Guid id, Guid animalId, int parity)
        {
            return Context.BreedingServices.Any(bs => bs.AnimalId == animalId && bs.Parity == parity && bs.Id != id);
        }
    }
}
