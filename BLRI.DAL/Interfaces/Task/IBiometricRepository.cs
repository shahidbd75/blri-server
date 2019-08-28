using System;
using System.Collections.Generic;
using BLRI.DAL.Interfaces.Core;
using BLRI.Entity.Task;
using BLRI.ViewModel.Biometric;

namespace BLRI.DAL.Interfaces.Task
{
    public interface IBiometricRepository: IRepository<Biometric>
    {
        List<BiometricViewModel> GetBiometricByAnimalId(Guid animalId);
        BiometricViewModel GetBiometricId(Guid id);
    }
}
