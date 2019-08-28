using AutoMapper;
using BLRI.Common.Enum;
using BLRI.DAL.Interfaces.Core;
using BLRI.Entity;
using BLRI.Manager.Interfaces.Task;
using BLRI.Manager.Map;
using BLRI.Manager.Services.Core;
using BLRI.ViewModel.Biometric;
using System;
using System.Collections.Generic;
using BLRI.Entity.Task;

namespace BLRI.Manager.Services.Task
{
    public class BiometricManager : BaseService, IBiometricManager
    {
        public BiometricManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<BiometricViewModel> GetAll()
        {
            var biometrics = UnitOfWork.BiometricRepository.GetAll();

            return Mapper.Map<IEnumerable<BiometricViewModel>>(biometrics);
        }

        public BiometricViewModel Get(object id)
        {
            var biometric = UnitOfWork.BiometricRepository.Find(id);

            var result = Mapper.Map<BiometricViewModel>(biometric);

            return result;
        }

        public ReasonCode Delete(object id)
        {
            var biometric = UnitOfWork.BiometricRepository.Find(id);
            if (biometric == null)
                return ReasonCode.NotFound;

            UnitOfWork.BiometricRepository.Remove(biometric);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Deleted : ReasonCode.OperationFailed;
        }

        public ReasonCode Add(BiometricViewModel viewModel)
        {
            var biometric = Mapper.Map<Biometric>(viewModel);
            biometric.Id = Guid.NewGuid();
            biometric.SetLastUpdateDate();
            biometric.SetCreateDate();
            biometric.BiometricUnit = UnitOfWork.BiometricUnitsRepository.Find(viewModel.BiometricUnitId);
            biometric.Animal = UnitOfWork.AnimalRepository.Find(viewModel.AnimalId);
            UnitOfWork.BiometricRepository.Add(biometric);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Created : ReasonCode.OperationFailed;
        }

        public ReasonCode Update(BiometricViewModel viewModel)
        {
            var biometric = UnitOfWork.BiometricRepository.Find(viewModel.Id);
            if (biometric == null)
            {
                return ReasonCode.NotFound;
            }
            biometric.UpdateBiometric(viewModel);
            biometric.SetLastUpdateDate();
            UnitOfWork.BiometricRepository.Update(biometric);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Updated : ReasonCode.OperationFailed;
        }

        public List<BiometricViewModel> GetBiometricByAnimalId(Guid animalId)
        {
            return UnitOfWork.BiometricRepository.GetBiometricByAnimalId(animalId);
        }

        public BiometricViewModel GetBiometricById(Guid id)
        {
            return UnitOfWork.BiometricRepository.GetBiometricId(id);
        }
    }
}
