using System;
using System.Collections.Generic;
using BLRI.Manager.Interfaces.Core;
using BLRI.ViewModel.Biometric;

namespace BLRI.Manager.Interfaces.Task
{
    public interface IParentageManager: IBaseService<BiometricViewModel>
    {
        List<BiometricViewModel> GetBiometricByAnimalId(Guid animalId);
    }
}
