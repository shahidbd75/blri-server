using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLRI.Common.Enum;
using BLRI.DAL.Interfaces.Core;
using BLRI.Entity.Units;
using BLRI.Manager.Interfaces.Units;
using BLRI.Manager.Services.Core;
using BLRI.ViewModel.Units;

namespace BLRI.Manager.Services.Units
{
    public class WeightUnitsManager : BaseService, IWeightUnitsManager
    {
        public WeightUnitsManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<WeightUnitViewModel> GetAll()
        {
            var weightUnit = UnitOfWork.WeightUnitsRepository.GetAll();

            return Mapper.Map<IEnumerable<WeightUnitViewModel>>(weightUnit);
        }

        public WeightUnitViewModel Get(object id)
        {
            var weightUnit = UnitOfWork.WeightUnitsRepository.Find(id);
            var result = Mapper.Map<WeightUnitViewModel>(weightUnit);

            return result;
        }

        public ReasonCode Delete(object id)
        {
            var weightUnit = UnitOfWork.WeightUnitsRepository.Find(id);
            if (weightUnit == null)
                return ReasonCode.NotFound;

            UnitOfWork.WeightUnitsRepository.Remove(weightUnit);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Deleted : ReasonCode.OperationFailed;
        }

        public ReasonCode Add(WeightUnitViewModel viewModel)
        {
            var weightUnit = Mapper.Map<WeightUnit>(viewModel);

            UnitOfWork.WeightUnitsRepository.Add(weightUnit);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Created : ReasonCode.OperationFailed;
        }

        public ReasonCode Update(WeightUnitViewModel viewModel)
        {
            var weightUnit = UnitOfWork.WeightUnitsRepository.Find(viewModel.Id);
            if (weightUnit == null)
            {
                return ReasonCode.NotFound;
            }

            weightUnit.Name = viewModel.Name;
            weightUnit.Value = viewModel.Value;
            UnitOfWork.WeightUnitsRepository.Update(weightUnit);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Updated : ReasonCode.OperationFailed;
        }
    }
}
