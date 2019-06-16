using AutoMapper;
using BLRI.Common.Enum;
using BLRI.DAL.Interfaces.Core;
using BLRI.Entity;
using BLRI.Manager.Interfaces.LookUp;
using BLRI.Manager.Services.Core;
using BLRI.ViewModel.LookUp;
using System.Collections.Generic;

namespace BLRI.Manager.Services.LookUp
{
    public class AnimalCategoryManager: BaseService, IAnimalCategoryManager
    {
        public AnimalCategoryManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<AnimalCategoryViewModel> GetAll()
        {
            var animalCategories =  UnitOfWork.AnimalCategoryRepository.GetAll();

            return Mapper.Map<IEnumerable<AnimalCategoryViewModel>>(animalCategories);
        }

        public AnimalCategoryViewModel Get(object id)
        {
            var animalCategory = UnitOfWork.AnimalCategoryRepository.Find(id);

            var result = Mapper.Map<AnimalCategoryViewModel>(animalCategory);

            return result;
        }

        public ReasonCode Delete(object id)
        {
            var chapter = UnitOfWork.AnimalCategoryRepository.Find(id);
            if (chapter == null)
                return ReasonCode.NotFound;

            UnitOfWork.AnimalCategoryRepository.Remove(chapter);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Deleted : ReasonCode.OperationFailed;
        }

        public ReasonCode Add(AnimalCategoryViewModel viewModel)
        {
            var animalCategory = Mapper.Map<AnimalCategory>(viewModel);
            UnitOfWork.AnimalCategoryRepository.Add(animalCategory);

            return UnitOfWork.Complete() >0 ? ReasonCode.Created : ReasonCode.OperationFailed;
        }

        public ReasonCode Update(AnimalCategoryViewModel viewModel)
        {
            var animalCategory = UnitOfWork.AnimalCategoryRepository.Find(viewModel.Id);
            if (animalCategory ==null)
            {
                return ReasonCode.NotFound;
            }

            UnitOfWork.AnimalCategoryRepository.Update(new AnimalCategory()
            {
                Name = viewModel.Name
            });

            return UnitOfWork.Complete() >0? ReasonCode.Updated: ReasonCode.OperationFailed;
        }
    }
}
