using BLRI.DAL.Interfaces.Animals;
using BLRI.DAL.Repositories.Core;
using BLRI.Entity.Animals;

namespace BLRI.DAL.Repositories.Animals
{
    public class AnimalCategoryRepository : Repository<AnimalCategory>, IAnimalCategoryRepository
    {
        public AnimalCategoryRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
