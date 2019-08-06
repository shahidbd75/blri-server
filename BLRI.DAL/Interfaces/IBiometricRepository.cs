using BLRI.DAL.Interfaces.Core;
using BLRI.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using BLRI.ViewModel.Biometric;

namespace BLRI.DAL.Interfaces
{
    public interface IBiometricRepository: IRepository<Biometric>
    {
        List<BiometricViewModel> GetBiometricByAnimalId(Guid animalId);
        BiometricViewModel GetBiometricId(Guid id);
    }
}
