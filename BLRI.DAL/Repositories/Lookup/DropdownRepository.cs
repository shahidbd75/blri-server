using System.Collections.Generic;
using System.Linq;
using BLRI.DAL.Interfaces.Core;
using BLRI.DAL.Interfaces.LookUp;
using BLRI.ViewModel.LookUp;

namespace BLRI.DAL.Repositories.Lookup
{
    public class DropdownRepository: IDropdownRepository
    {
        private readonly IApplicationDbContext _context;

        public DropdownRepository(IApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public IEnumerable<DropdownViewModel<long>> GetBiometricUnitsDropdown()
        {
            var biometricUnits = _context.BiometricUnit.Select(b => new DropdownViewModel<long>()
            {
                Id = b.Id,
                Name = b.Name
            });
            return biometricUnits;
        }

        public IEnumerable<DropdownViewModel<long>> GetGrowthUnitsDropdown()
        {
            var growthUnits = _context.GrowthUnit.Select(b => new DropdownViewModel<long>()
            {
                Id = b.Id,
                Name = b.Name
            });
            return growthUnits;
        }

        public IEnumerable<DropdownViewModel<long>> GetWeightUnitsDropdown()
        {
            var weightUnits = _context.WeightUnit.Select(b => new DropdownViewModel<long>()
            {
                Id = b.Id,
                Name = b.Name
            });
            return weightUnits;
        }
    }
}
