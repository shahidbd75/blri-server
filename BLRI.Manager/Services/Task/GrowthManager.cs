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
            var growths = UnitOfWork.GrowthRepository.GetAll();

            return Mapper.Map<IEnumerable<GrowthViewModel>>(growths);
        }

        public GrowthViewModel Get(object id)
        {
            var growth = UnitOfWork.GrowthRepository.Find(id);

            var result = Mapper.Map<GrowthViewModel>(growth);

            return result;
        }

        public ReasonCode Delete(object id)
        {
            var growth = UnitOfWork.GrowthRepository.Find(id);
            if (growth == null)
                return ReasonCode.NotFound;

            UnitOfWork.GrowthRepository.Remove(growth);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Deleted : ReasonCode.OperationFailed;
        }

        public ReasonCode Add(GrowthViewModel viewModel)
        {
            var growth = Mapper.Map<Growth>(viewModel);
            growth.Id = Guid.NewGuid();
            growth.SetLastUpdateDate();
            growth.SetCreateDate();
            growth.GrowthUnit = UnitOfWork.GrowthUnitsRepository.Find(growth.GrowthUnitId);
            UnitOfWork.GrowthRepository.Add(growth);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Created : ReasonCode.OperationFailed;
        }

        public ReasonCode Update(GrowthViewModel viewModel)
        {
            var growth = UnitOfWork.GrowthRepository.Find(viewModel.Id);
            if (growth == null)
            {
                return ReasonCode.NotFound;
            }
           // growth.UpdateGrowth(viewModel);
            growth.SetLastUpdateDate();
            UnitOfWork.GrowthRepository.Update(growth);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Updated : ReasonCode.OperationFailed;
        }

        public List<GrowthViewModel> GetGrowthByAnimalId(Guid animalId)
        {
            return UnitOfWork.GrowthRepository.GetGrowthInfoByAnimalId(animalId);
        }
    }
}
