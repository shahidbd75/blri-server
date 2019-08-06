using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLRI.DAL.Interfaces;
using BLRI.DAL.Repositories.Core;
using BLRI.Entity;
using BLRI.ViewModel.Biometric;
using BLRI.ViewModel.Health;

namespace BLRI.DAL.Repositories
{
    public class HealthRepository : Repository<Health>, IHealthRepository
    {
        public HealthRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<HealthViewModel> GetHealthByAnimalId(Guid animalId)
        {
            var health = from h in Context.Health
                join a in Context.Animal on h.AnimalId equals a.Id
                select new HealthViewModel()
                {
                    Id = h.Id,
                    AnimalId = h.AnimalId,
                    DeWorming = h.DeWorming,
                    Disease = h.Disease,
                    Parasite = h.Parasite,
                    Treatment = h.Treatment,
                    Vaccination = h.Vaccination
                };
            return health.ToList();
        }
    }
}
