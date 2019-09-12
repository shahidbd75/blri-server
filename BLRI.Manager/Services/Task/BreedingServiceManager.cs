using AutoMapper;
using BLRI.Common.Enum;
using BLRI.DAL.Interfaces.Core;
using BLRI.Entity.Task;
using BLRI.Manager.Interfaces.Task;
using BLRI.Manager.Services.Core;
using BLRI.ViewModel.BreedingService;
using System;
using System.Collections.Generic;

namespace BLRI.Manager.Services.Task
{
    public class BreedingServiceManager: BaseService, IBreedingServiceManager
    {
        public BreedingServiceManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public BreedingServiceViewModel Get(object id)
        {
            var breedingService = UnitOfWork.BreedingServiceRepository.GetBreedingById(id);

            return breedingService;
        }

        public ReasonCode Delete(object id)
        {
            var breeding = UnitOfWork.BreedingServiceRepository.Find(id);
            if (breeding == null)
                return ReasonCode.NotFound;

            UnitOfWork.BreedingServiceRepository.Remove(breeding);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Deleted : ReasonCode.OperationFailed;
        }

        public ReasonCode Add(BreedingServiceViewModel viewModel)
        {
            var bService = Mapper.Map<BreedingService>(viewModel);
            bService.Id = Guid.NewGuid();
            bService.UpdatedByUserId = viewModel.UpdatedByUserId;
            bService.SetCreateUserId();
            bService.SetLastUpdateDate();
            bService.SetCreateDate();
            UnitOfWork.BreedingServiceRepository.Add(bService);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Created : ReasonCode.OperationFailed;
        }

        public ReasonCode Update(BreedingServiceViewModel viewModel)
        {
            var breeding = UnitOfWork.BreedingServiceRepository.Find(viewModel.Id);
            if (breeding == null)
            {
                return ReasonCode.NotFound;
            }

            breeding.Parity = viewModel.Parity;
            if (viewModel.CalvingDate != DateTime.MaxValue)
            {
                breeding.CalvingDate = viewModel.CalvingDate;
            }
            breeding.UpdatedByUserId = viewModel.UpdatedByUserId;
            breeding.SetCreateUserId();
            breeding.SetLastUpdateDate();
            UnitOfWork.BreedingServiceRepository.Update(breeding);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Updated : ReasonCode.OperationFailed;
        }

        public List<BreedingServiceListViewModel> GetBreedingServiceByAnimalId(Guid animalId)
        {
            return UnitOfWork.BreedingServiceRepository.GetBreedingServiceByAnimalId(animalId);
        }

        public bool IsExistBreedingServiceByParity(Guid animalId, int parity)
        {
            return UnitOfWork.BreedingServiceRepository.IsExistBreedingServiceByParity(animalId, parity);
        }

        public bool IsExistBreedingServiceByParityOther(Guid id, Guid animalId, int parity)
        {
            return UnitOfWork.BreedingServiceRepository.IsExistBreedingServiceByParityOther(id, animalId, parity);
        }

        public IEnumerable<BreedingServiceViewModel> GetAll()
        {
            var bService = UnitOfWork.BreedingServiceRepository.GetAll();

            return Mapper.Map<IEnumerable<BreedingServiceViewModel>>(bService);
        }
    }
}
