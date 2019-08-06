using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLRI.DAL.Interfaces.Core;
using BLRI.Manager.Interfaces.LookUp;
using BLRI.Manager.Services.Core;
using BLRI.ViewModel.LookUp;

namespace BLRI.Manager.Services.LookUp
{
    public class DropdownManager: BaseService, IDropdownManager
    {
        public DropdownManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public List<DropdownViewModel<long>> GetBiometricUnitsDropdown()
        {
            return UnitOfWork.DropdownRepository.GetBiometricUnitsDropdown().ToList();
        }

        public List<DropdownViewModel<long>> GetGrowthUnitsDropdown()
        {
            return UnitOfWork.DropdownRepository.GetGrowthUnitsDropdown().ToList();
        }

        public List<DropdownViewModel<long>> GetWeightUnitsDropdown()
        {
            return UnitOfWork.DropdownRepository.GetWeightUnitsDropdown().ToList();
        }

        public List<DropdownViewModel<long>> GetAnimalCategoriesDropdown()
        {
            return UnitOfWork.DropdownRepository.GetAnimalCategoryDropdown().ToList();
        }

        public List<DropdownViewModel<Int32>> GetGenderDropdown()
        {
            return UnitOfWork.DropdownRepository.GetGenderDropdown().ToList();
        }

        public List<DropdownViewModel<int>> GetGenotypeDropdown()
        {
            return UnitOfWork.DropdownRepository.GetGenotypeDropdown().ToList();
        }
    }
}
