using System.Collections.Generic;
using BLRI.Entity.Base;

namespace BLRI.Entity.Units
{
    public class BiometricUnit: BaseUnit
    {
        public ICollection<Biometric> Biometrics { get; set; }
    }
}
