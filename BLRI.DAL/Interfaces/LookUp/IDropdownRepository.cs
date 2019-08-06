using System;
using BLRI.ViewModel.LookUp;
using System.Collections.Generic;

namespace BLRI.DAL.Interfaces.LookUp
{
    public interface IDropdownRepository
    {
        IEnumerable<DropdownViewModel<long>> GetBiometricUnitsDropdown();
        IEnumerable<DropdownViewModel<long>> GetGrowthUnitsDropdown();
        IEnumerable<DropdownViewModel<long>> GetWeightUnitsDropdown();
        IEnumerable<DropdownViewModel<long>> GetAnimalCategoryDropdown();
        IEnumerable<DropdownViewModel<Int32>> GetGenderDropdown();
        IEnumerable<DropdownViewModel<Int32>> GetGenotypeDropdown();
    }
}
