using System;
using System.Collections.Generic;
using BLRI.Entity.Animals;
using BLRI.DAL.Interfaces.Core;
using BLRI.ViewModel.Animals;
using BLRI.ViewModel.LookUp;

namespace BLRI.DAL.Interfaces.Animals
{
    public interface IAnimalRepository:IRepository<Animal>
    {
        IEnumerable<DropdownViewModel<Guid>> GetAnimalsByCategoryId(int categoryId);
        List<AnimalListViewModel> GetAnimalListBy();
        AnimalListViewModel GetAnimalInfoById(Guid id);
        IEnumerable<DropdownViewModel<Guid>> GetDamSireByCategoryId(int categoryId, int genderId);
        string GenerateAnimalId(string prefix);
    }
}
