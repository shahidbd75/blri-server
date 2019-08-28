using AutoMapper;
using BLRI.Common.Enum;
using BLRI.DAL.Interfaces.Core;
using BLRI.Entity.Task;
using BLRI.Manager.Interfaces.Task;
using BLRI.Manager.Services.Core;
using BLRI.ViewModel.Milk_Yield;
using System;
using System.Collections.Generic;

namespace BLRI.Manager.Services.Task
{
    public class MilkYieldManager : BaseService, IMilkYieldManager
    {
        public MilkYieldManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<MilkYieldViewModel> GetAll()
        {
            var milkYields = UnitOfWork.MilkYieldRepository.GetAll();

            return Mapper.Map<IEnumerable<MilkYieldViewModel>>(milkYields);
        }

        public MilkYieldViewModel Get(object id)
        {
            var milkYield = UnitOfWork.MilkYieldRepository.Find(id);

            var result = Mapper.Map<MilkYieldViewModel>(milkYield);

            return result;
        }

        public ReasonCode Delete(object id)
        {
            var milkYield = UnitOfWork.MilkYieldRepository.Find(id);
            if (milkYield == null)
                return ReasonCode.NotFound;

            UnitOfWork.MilkYieldRepository.Remove(milkYield);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Deleted : ReasonCode.OperationFailed;
        }

        public ReasonCode Add(MilkYieldViewModel viewModel)
        {
            var milkYield = Mapper.Map<MilkYield>(viewModel);
            milkYield.Id = Guid.NewGuid();
            milkYield.SetLastUpdateDate();
            milkYield.SetCreateDate();
            UnitOfWork.MilkYieldRepository.Add(milkYield);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Created : ReasonCode.OperationFailed;
        }

        public ReasonCode Update(MilkYieldViewModel viewModel)
        {
            var milkYiels = UnitOfWork.MilkYieldRepository.Find(viewModel.Id);
            if (milkYiels == null)
            {
                return ReasonCode.NotFound;
            }
            //milkYiels.UpdateBiometric(viewModel);
            milkYiels.SetLastUpdateDate();
            UnitOfWork.MilkYieldRepository.Update(milkYiels);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Updated : ReasonCode.OperationFailed;
        }

        public List<MilkYieldViewModel> GetMilkYieldByAnimalId(Guid animalId)
        {
            return UnitOfWork.MilkYieldRepository.GetMilkYieldInfoByAnimalId(animalId);
        }
    }
}
