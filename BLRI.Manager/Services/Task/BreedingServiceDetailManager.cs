using AutoMapper;
using BLRI.Common.Enum;
using BLRI.DAL.Interfaces.Core;
using BLRI.Entity.Task;
using BLRI.Manager.Interfaces.Task;
using BLRI.Manager.Services.Core;
using BLRI.ViewModel.BreedingService;
using System;
using System.Collections.Generic;
using BLRI.ViewModel.BreedingServiceDetail;

namespace BLRI.Manager.Services.Task
{
    public class BreedingServiceDetailManager: BaseService, IBreedingServiceDetailManager
    {
        public BreedingServiceDetailManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public BreedingServiceDetailViewModel Get(object id)
        {
            var breedingService = UnitOfWork.BreedingServiceDetailRepository.Find(id);

            var result = Mapper.Map<BreedingServiceDetailViewModel>(breedingService);

            return result;
        }

        public ReasonCode Delete(object id)
        {
            var breedingServiceDetail = UnitOfWork.BreedingServiceDetailRepository.Find(id);
            if (breedingServiceDetail == null)
                return ReasonCode.NotFound;

            UnitOfWork.BreedingServiceDetailRepository.Remove(breedingServiceDetail);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Deleted : ReasonCode.OperationFailed;
        }

        public ReasonCode Add(BreedingServiceViewModel viewModel)
        {
            var bServiceDetail = Mapper.Map<BreedingServiceDetail>(viewModel);
            bServiceDetail.Id = Guid.NewGuid();
            bServiceDetail.UpdatedByUserId = viewModel.UpdatedByUserId;
            bServiceDetail.SetCreateUserId();
            bServiceDetail.SetLastUpdateDate();
            bServiceDetail.SetCreateDate();
            UnitOfWork.BreedingServiceDetailRepository.Add(bServiceDetail);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Created : ReasonCode.OperationFailed;
        }

        public ReasonCode Update(BreedingServiceDetailViewModel viewModel)
        {
            var breedingServiceDetail = UnitOfWork.BreedingServiceDetailRepository.Find(viewModel.Id);
            if (breedingServiceDetail == null)
            {
                return ReasonCode.NotFound;
            }

            breedingServiceDetail.EstrousDate = viewModel.EstrousDate;
            if (viewModel.ServiceDate != DateTime.MaxValue)
            {
                breedingServiceDetail.ServiceDate = viewModel.ServiceDate;
            }

            breedingServiceDetail.ServiceConfirmed = viewModel.ServiceConfirmed;
            breedingServiceDetail.UpdatedByUserId = viewModel.UpdatedByUserId;
            breedingServiceDetail.SetCreateUserId();
            breedingServiceDetail.SetLastUpdateDate();
            UnitOfWork.BreedingServiceDetailRepository.Update(breedingServiceDetail);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Updated : ReasonCode.OperationFailed;
        }

        public List<BreedingServiceDetailViewModel> GetBreedingServiceDetailById(Guid serviceId)
        {
            return UnitOfWork.BreedingServiceDetailRepository.GetBreedingServiceDetailById(serviceId);
        }

        public IEnumerable<BreedingServiceDetailViewModel> GetAll()
        {
            var bServiceDetail = UnitOfWork.BreedingServiceDetailRepository.GetAll();

            return Mapper.Map<IEnumerable<BreedingServiceDetailViewModel>>(bServiceDetail);
        }

        public ReasonCode Add(BreedingServiceDetailViewModel viewModel)
        {
            var breedingServiceDetail = Mapper.Map<BreedingServiceDetail>(viewModel);
            breedingServiceDetail.Id = Guid.NewGuid();
            breedingServiceDetail.SetLastUpdateDate();
            breedingServiceDetail.SetCreateDate();
            breedingServiceDetail.UpdatedByUserId = viewModel.UpdatedByUserId;
            breedingServiceDetail.SetCreateUserId();
            UnitOfWork.BreedingServiceDetailRepository.Add(breedingServiceDetail);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Created : ReasonCode.OperationFailed;
        }
    }
}
