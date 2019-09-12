using BLRI.DAL.Interfaces.Core;
using BLRI.Entity.Task;
using BLRI.ViewModel.BreedingServiceDetail;
using System;
using System.Collections.Generic;

namespace BLRI.DAL.Interfaces.Task
{
    public interface IBreedingServiceDetailRepository: IRepository<BreedingServiceDetail>
    {
        List<BreedingServiceDetailViewModel> GetBreedingServiceDetailById(Guid serviceId);
    }
}