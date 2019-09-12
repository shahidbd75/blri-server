using System;
using System.Collections.Generic;
using BLRI.Manager.Interfaces.Core;
using BLRI.ViewModel.BreedingServiceDetail;

namespace BLRI.Manager.Interfaces.Task
{
    public interface IBreedingServiceDetailManager: IBaseService<BreedingServiceDetailViewModel>
    {
        List<BreedingServiceDetailViewModel> GetBreedingServiceDetailById(Guid serviceId);
    }
}
