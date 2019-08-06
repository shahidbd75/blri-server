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
    public class BiometricUnitsManager : BaseService, IBiometricUnitsManager
    {
        public BiometricUnitsManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<BiometricUnitViewModel> GetAll()
        {
            var biometricUnits = UnitOfWork.BiometricUnitsRepository.GetAll();

            return Mapper.Map<IEnumerable<BiometricUnitViewModel>>(biometricUnits);
        }

        public BiometricUnitViewModel Get(object id)
        {
            var biometricUnit = UnitOfWork.BiometricUnitsRepository.Find(id);
            var result = Mapper.Map<BiometricUnitViewModel>(biometricUnit);

            return result; 
        }

        public ReasonCode Delete(object id)
        {
            var biometric = UnitOfWork.BiometricUnitsRepository.Find(id);
            if (biometric == null)
                return ReasonCode.NotFound;

            UnitOfWork.BiometricUnitsRepository.Remove(biometric);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Deleted : ReasonCode.OperationFailed;
        }

        public ReasonCode Add(BiometricUnitViewModel viewModel)
        {
            var biometric = Mapper.Map<BiometricUnit>(viewModel);
            
            UnitOfWork.BiometricUnitsRepository.Add(biometric);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Created : ReasonCode.OperationFailed;
        }

        public ReasonCode Update(BiometricUnitViewModel viewModel)
        {
            var biometric = UnitOfWork.BiometricUnitsRepository.Find(viewModel.Id);
            if (biometric == null)
            {
                return ReasonCode.NotFound;
            }

            biometric.Name = viewModel.Name;
            biometric.Value = viewModel.Value;
            UnitOfWork.BiometricUnitsRepository.Update(biometric);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Updated : ReasonCode.OperationFailed;
        }
    }
}
