using System;
using System.Collections.Generic;
using System.Linq;
using BLRI.DAL.Interfaces.Core;
using BLRI.DAL.Interfaces.LookUp;
using BLRI.Entity.Animals;
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

        public IEnumerable<DropdownViewModel<long>> GetAnimalCategoryDropdown()
        {
            var animalCategories = _context.AnimalCategory.Select(b => new DropdownViewModel<long>()
            {
                Id = b.Id,
                Name = b.Name
            });
            return animalCategories;
        }

        public IEnumerable<DropdownViewModel<Int32>> GetGenderDropdown()
        {
            return (from Gender gender in Enum.GetValues(typeof(Gender))
                select new DropdownViewModel<int>
                {
                    Id = (int)gender,
                    Name = gender.ToString()
                }).ToList();
        }

        public IEnumerable<DropdownViewModel<int>> GetGenotypeDropdown()
        {
            var genotypes = _context.Genotype.Select(b => new DropdownViewModel<int>()
            {
                Id = b.Id,
                Name = b.Name
            });
            return genotypes;
        }
    }
}
