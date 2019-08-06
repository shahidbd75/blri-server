using AutoMapper;
using BLRI.Common.Enum;
using BLRI.DAL.Interfaces.Core;
using BLRI.Entity;
using BLRI.Manager.Interfaces.Task;
using BLRI.Manager.Map;
using BLRI.Manager.Services.Core;
using BLRI.ViewModel.Breeding;
using System;
using System.Collections.Generic;

namespace BLRI.Manager.Services.Task
{
    public class BreedingManager: BaseService, IBreedingManager
    {
        public BreedingManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<BreedingViewModel> GetAll()
        {
            var breeds = UnitOfWork.BreedingRepository.GetAll();

            return Mapper.Map<IEnumerable<BreedingViewModel>>(breeds);
        }

        public BreedingViewModel Get(object id)
        {
            var breed = UnitOfWork.BreedingRepository.Find(id);

            var result = Mapper.Map<BreedingViewModel>(breed);

            return result;
        }

        public ReasonCode Delete(object id)
        {
            var breeding = UnitOfWork.BreedingRepository.Find(id);
            if (breeding == null)
                return ReasonCode.NotFound;

            UnitOfWork.BiometricRepository.Remove(breeding);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Deleted : ReasonCode.OperationFailed;
        }

        public ReasonCode Add(BreedingViewModel viewModel)
        {
            var breeding = Mapper.Map<Breeding>(viewModel);
            breeding.Id = Guid.NewGuid();
            breeding.SetLastUpdateDate();
            breeding.SetCreateDate();
            UnitOfWork.BreedingRepository.Add(breeding);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Created : ReasonCode.OperationFailed;
        }

        public ReasonCode Update(BreedingViewModel viewModel)
        {
            var breeding = UnitOfWork.BreedingRepository.Find(viewModel.Id);
            if (breeding == null)
            {
                return ReasonCode.NotFound;
            }
            breeding.UpdateBreeding(viewModel);
            breeding.SetLastUpdateDate();
            UnitOfWork.BreedingRepository.Update(breeding);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Updated : ReasonCode.OperationFailed;
        }

        public List<BreedingViewModel> GetBreedingByAnimalId(Guid animalId)
        {
            return UnitOfWork.BreedingRepository.GetBreedingByAnimalId(animalId);
        }
    }
}
