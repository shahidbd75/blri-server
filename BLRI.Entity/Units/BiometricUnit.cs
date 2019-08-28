using System.Collections.Generic;
using BLRI.Entity.Base;
using BLRI.Entity.Task;

namespace BLRI.Entity.Units
{
    public class BiometricUnit: BaseUnit
    {
        public ICollection<Biometric> Biometrics { get; set; }
    }
}
