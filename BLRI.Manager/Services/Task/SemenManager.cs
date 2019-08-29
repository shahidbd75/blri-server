using AutoMapper;
using BLRI.Common.Enum;
using BLRI.DAL.Interfaces.Core;
using BLRI.Entity.Task;
using BLRI.Manager.Interfaces.Task;
using BLRI.Manager.Services.Core;
using BLRI.ViewModel.Semen;
using System;
using System.Collections.Generic;

namespace BLRI.Manager.Services.Task
{
    public class SemenManager: BaseService, ISemenManager
    {
        public SemenManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<SemenViewModel> GetAll()
        {
            var semens = UnitOfWork.SemenRepository.GetAll();

            return Mapper.Map<IEnumerable<SemenViewModel>>(semens);
        }

        public SemenViewModel Get(object id)
        {
            var semen = UnitOfWork.SemenRepository.Find(id);

            var result = Mapper.Map<SemenViewModel>(semen);

            return result;
        }

        public ReasonCode Delete(object id)
        {
            var semen = UnitOfWork.SemenRepository.Find(id);
            if (semen == null)
                return ReasonCode.NotFound;

            UnitOfWork.SemenRepository.Remove(semen);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Deleted : ReasonCode.OperationFailed;
        }

        public ReasonCode Add(SemenViewModel viewModel)
        {
            var semen = Mapper.Map<Semen>(viewModel);
            semen.Id = Guid.NewGuid();
            semen.Id = Guid.NewGuid();
            semen.UpdatedByUserId = viewModel.UpdatedByUserId;
            semen.SetCreateUserId();
            semen.SetLastUpdateDate();
            semen.SetCreateDate();
            UnitOfWork.SemenRepository.Add(semen);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Created : ReasonCode.OperationFailed;
        }

        public ReasonCode Update(SemenViewModel viewModel)
        {
            var semen = UnitOfWork.SemenRepository.Find(viewModel.Id);
            if (semen == null)
            {
                return ReasonCode.NotFound;
            }
            // semen.UpdateBiometric(viewModel);
            semen.UpdatedByUserId = viewModel.UpdatedByUserId;
            semen.SetCreateUserId();
            semen.SetLastUpdateDate();
            UnitOfWork.SemenRepository.Update(semen);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Updated : ReasonCode.OperationFailed;
        }

        public List<SemenViewModel> GetSemenByAnimalId(Guid animalId)
        {
            return UnitOfWork.SemenRepository.GetMilkYieldInfoByAnimalId(animalId);
        }
    }
}
