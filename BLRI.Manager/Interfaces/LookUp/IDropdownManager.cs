using System;
using System.Collections.Generic;
using BLRI.ViewModel.LookUp;

namespace BLRI.Manager.Interfaces.LookUp
{
    public interface IDropdownManager
    {
        List<DropdownViewModel<long>> GetBiometricUnitsDropdown();
        List<DropdownViewModel<long>> GetGrowthUnitsDropdown();
        List<DropdownViewModel<long>> GetWeightUnitsDropdown();
        List<DropdownViewModel<long>> GetAnimalCategoriesDropdown();
        List<DropdownViewModel<Int32>> GetGenderDropdown();
        List<DropdownViewModel<Int32>> GetGenotypeDropdown();
    }
}