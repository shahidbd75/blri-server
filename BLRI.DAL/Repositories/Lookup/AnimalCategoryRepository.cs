using BLRI.DAL.Interfaces.LookUp;
using BLRI.DAL.Repositories.Core;
using BLRI.Entity;

namespace BLRI.DAL.Repositories.Lookup
{
    public class AnimalCategoryRepository : Repository<AnimalCategory>, IAnimalCategoryRepository
    {
        public AnimalCategoryRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
