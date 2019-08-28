using AutoMapper;
using BLRI.Common.Enum;
using BLRI.DAL.Interfaces.Core;
using BLRI.Entity.Task;
using BLRI.Manager.Interfaces.Task;
using BLRI.Manager.Map;
using BLRI.Manager.Services.Core;
using BLRI.ViewModel.Live_Weight;
using System;
using System.Collections.Generic;

namespace BLRI.Manager.Services.Task
{
    public class LiveWeightManager : BaseService, ILiveWeightManager
    {
        public LiveWeightManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<LiveWeightViewModel> GetAll()
        {
            var liveWeights = UnitOfWork.LiveWeightRepository.GetAll();

            return Mapper.Map<IEnumerable<LiveWeightViewModel>>(liveWeights);
        }

        public LiveWeightViewModel Get(object id)
        {
            var liveWeight = UnitOfWork.LiveWeightRepository.Find(id);

            var result = Mapper.Map<LiveWeightViewModel>(liveWeight);

            return result;
        }

        public ReasonCode Delete(object id)
        {
            var biometric = UnitOfWork.LiveWeightRepository.Find(id);
            if (biometric == null)
                return ReasonCode.NotFound;

            UnitOfWork.LiveWeightRepository.Remove(biometric);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Deleted : ReasonCode.OperationFailed;
        }

        public ReasonCode Add(LiveWeightViewModel viewModel)
        {
            var liveWeight = Mapper.Map<LiveWeight>(viewModel);
            liveWeight.Id = Guid.NewGuid();
            liveWeight.SetLastUpdateDate();
            liveWeight.SetCreateDate();
            liveWeight.WeightUnit = UnitOfWork.WeightUnitsRepository.Find(liveWeight.WeightUnitId);
            UnitOfWork.LiveWeightRepository.Add(liveWeight);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Created : ReasonCode.OperationFailed;
        }

        public ReasonCode Update(LiveWeightViewModel viewModel)
        {
            var liveWeight = UnitOfWork.LiveWeightRepository.Find(viewModel.Id);
            if (liveWeight == null)
            {
                return ReasonCode.NotFound;
            }
            liveWeight.UpdateLiveWeight(viewModel);
            liveWeight.SetLastUpdateDate();
            UnitOfWork.LiveWeightRepository.Update(liveWeight);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Updated : ReasonCode.OperationFailed;
        }

        public List<LiveWeightViewModel> GetLiveWeightByAnimalId(Guid animalId)
        {
            return UnitOfWork.LiveWeightRepository.GetLiveWeightByAnimalId(animalId);
        }

        public LiveWeightViewModel GetLiveWeightById(Guid id)
        {
            return UnitOfWork.LiveWeightRepository.GetLiveWeightById(id);
        }
    }
}
