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
    public class GrowthUnitsManager: BaseService, IGrowthUnitsManager
    {
        public GrowthUnitsManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<GrowthUnitViewModel> GetAll()
        {
            var growthUnits = UnitOfWork.GrowthUnitsRepository.GetAll();

            return Mapper.Map<IEnumerable<GrowthUnitViewModel>>(growthUnits);
        }

        public GrowthUnitViewModel Get(object id)
        {
            var biometricUnit = UnitOfWork.GrowthUnitsRepository.Find(id);
            var result = Mapper.Map<GrowthUnitViewModel>(biometricUnit);

            return result;
        }

        public ReasonCode Delete(object id)
        {
            var growthUnit = UnitOfWork.GrowthUnitsRepository.Find(id);
            if (growthUnit == null)
                return ReasonCode.NotFound;

            UnitOfWork.GrowthUnitsRepository.Remove(growthUnit);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Deleted : ReasonCode.OperationFailed;
        }

        public ReasonCode Add(GrowthUnitViewModel viewModel)
        {
            var growthUnit = Mapper.Map<GrowthUnit>(viewModel);

            UnitOfWork.GrowthUnitsRepository.Add(growthUnit);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Created : ReasonCode.OperationFailed;
        }

        public ReasonCode Update(GrowthUnitViewModel viewModel)
        {
            var growthUnit = UnitOfWork.GrowthUnitsRepository.Find(viewModel.Id);
            if (growthUnit == null)
            {
                return ReasonCode.NotFound;
            }

            growthUnit.Name = viewModel.Name;
            growthUnit.Value = viewModel.Value;
            UnitOfWork.GrowthUnitsRepository.Update(growthUnit);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Updated : ReasonCode.OperationFailed;
        }
    }
}
