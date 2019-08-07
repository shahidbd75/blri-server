using AutoMapper;
using BLRI.Common.Enum;
using BLRI.DAL.Interfaces.Core;
using BLRI.Entity;
using BLRI.Manager.Interfaces.Task;
using BLRI.Manager.Services.Core;
using BLRI.ViewModel.Growth;
using System;
using System.Collections.Generic;

namespace BLRI.Manager.Services.Task
{
    public class GrowthManager : BaseService, IGrowthManager
    {
        public GrowthManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<GrowthViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public GrowthViewModel Get(object id)
        {
            throw new NotImplementedException();
        }

        public ReasonCode Delete(object id)
        {
            throw new NotImplementedException();
            //            var growth = UnitOfWork.GrowthRepository.Find(id);
            //            if (growth == null)
            //                return ReasonCode.NotFound;
            //
            //            UnitOfWork.GrowthRepository.Remove(growth);
            //
            //            return UnitOfWork.Complete() > 0 ? ReasonCode.Deleted : ReasonCode.OperationFailed;
        }

        public ReasonCode Add(GrowthViewModel viewModel)
        {
            throw new NotImplementedException();
            //            var growth = Mapper.Map<Growth>(viewModel);
            //            growth.Id = Guid.NewGuid();
            //            growth.SetLastUpdateDate();
            //            growth.SetCreateDate();
            //            growth.GrowthUnit = UnitOfWork.GrowthUnitsRepository.Find(growth.GrowthUnitId);
            //            UnitOfWork.GrowthRepository.Add(growth);
            //
            //            return UnitOfWork.Complete() > 0 ? ReasonCode.Created : ReasonCode.OperationFailed;
        }

        public ReasonCode Update(GrowthViewModel viewModel)
        {
            throw new NotImplementedException();
            //            var growth = UnitOfWork.GrowthRepository.Find(viewModel.Id);
            //            if (growth == null)
            //            {
            //                return ReasonCode.NotFound;
            //            }
            //           // growth.UpdateGrowth(viewModel);
            //            growth.SetLastUpdateDate();
            //            UnitOfWork.GrowthRepository.Update(growth);
            //
            //            return UnitOfWork.Complete() > 0 ? ReasonCode.Updated : ReasonCode.OperationFailed;
        }

        public List<GrowthViewModel> GetGrowthByAnimalId(Guid animalId)
        {
            throw new NotImplementedException();
            //            return UnitOfWork.GrowthRepository.GetGrowthInfoByAnimalId(animalId);
        }
    }
}
