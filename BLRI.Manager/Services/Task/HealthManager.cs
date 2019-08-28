using AutoMapper;
using BLRI.Common.Enum;
using BLRI.DAL.Interfaces.Core;
using BLRI.Entity.Task;
using BLRI.Manager.Interfaces.Task;
using BLRI.Manager.Services.Core;
using BLRI.ViewModel.Health;
using System;
using System.Collections.Generic;

namespace BLRI.Manager.Services.Task
{
    public class HealthManager : BaseService, IHealthManager
    {
        public HealthManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<HealthViewModel> GetAll()
        {
            var healths = UnitOfWork.HealthRepository.GetAll();

            return Mapper.Map<IEnumerable<HealthViewModel>>(healths);
        }

        public HealthViewModel Get(object id)
        {
            var health = UnitOfWork.HealthRepository.Find(id);

            var result = Mapper.Map<HealthViewModel>(health);

            return result;
        }

        public ReasonCode Delete(object id)
        {
            var health = UnitOfWork.HealthRepository.Find(id);
            if (health == null)
                return ReasonCode.NotFound;

            UnitOfWork.HealthRepository.Remove(health);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Deleted : ReasonCode.OperationFailed;
        }

        public ReasonCode Add(HealthViewModel viewModel)
        {
            var health = Mapper.Map<Health>(viewModel);
            health.Id = Guid.NewGuid();
            health.SetLastUpdateDate();
            health.SetCreateDate();
            UnitOfWork.HealthRepository.Add(health);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Created : ReasonCode.OperationFailed;
        }

        public ReasonCode Update(HealthViewModel viewModel)
        {
            var health = UnitOfWork.HealthRepository.Find(viewModel.Id);
            if (health == null)
            {
                return ReasonCode.NotFound;
            }
           // health.UpdateHealth(viewModel);
            health.SetLastUpdateDate();
            UnitOfWork.HealthRepository.Update(health);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Updated : ReasonCode.OperationFailed;
        }

        public List<HealthViewModel> GetHealthByAnimalId(Guid animalId)
        {
            return UnitOfWork.HealthRepository.GetHealthByAnimalId(animalId);
        }
    }
}
