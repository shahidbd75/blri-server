using System;
using System.Collections.Generic;
using BLRI.Manager.Interfaces.Core;
using BLRI.ViewModel.Biometric;

namespace BLRI.Manager.Interfaces.Task
{
    public interface IBiometricManager: IBaseService<BiometricViewModel>
    {
        List<BiometricViewModel> GetBiometricByAnimalId(Guid animalId);
        BiometricViewModel GetBiometricById(Guid id);

        BiometricViewModel GetBiometric(Guid animalId, long biometricUnitId);
    }
}
