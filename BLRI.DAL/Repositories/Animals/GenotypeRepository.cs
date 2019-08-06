using BLRI.DAL.Interfaces.Animals;
using BLRI.DAL.Repositories.Core;
using BLRI.Entity.Animals;

namespace BLRI.DAL.Repositories.Animals
{
    public class GenotypeRepository : Repository<Genotype>, IGenotypeRepository
    {
        public GenotypeRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
