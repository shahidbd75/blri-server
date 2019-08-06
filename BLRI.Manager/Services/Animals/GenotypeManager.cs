using System.Collections.Generic;
using AutoMapper;
using BLRI.Common.Enum;
using BLRI.DAL.Interfaces.Core;
using BLRI.Entity.Animals;
using BLRI.Manager.Interfaces.Animals;
using BLRI.Manager.Services.Core;
using BLRI.ViewModel.Animals;

namespace BLRI.Manager.Services.Animals
{
    public class GenotypeManager: BaseService, IGenotypeManager
    {
        public GenotypeManager(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<GenotypeViewModel> GetAll()
        {
            var genotypes =  UnitOfWork.GenotypeRepository.GetAll();

            return Mapper.Map<IEnumerable<GenotypeViewModel>>(genotypes);
        }

        public GenotypeViewModel Get(object id)
        {
            var animalCategory = UnitOfWork.GenotypeRepository.Find(id);

            var result = Mapper.Map<GenotypeViewModel>(animalCategory);

            return result;
        }

        public ReasonCode Delete(object id)
        {
            var genotype = UnitOfWork.GenotypeRepository.Find(id);
            if (genotype == null)
                return ReasonCode.NotFound;

            UnitOfWork.GenotypeRepository.Remove(genotype);

            return UnitOfWork.Complete() > 0 ? ReasonCode.Deleted : ReasonCode.OperationFailed;
        }

        public ReasonCode Add(GenotypeViewModel viewModel)
        {
            var genotype = Mapper.Map<Genotype>(viewModel);
            UnitOfWork.GenotypeRepository.Add(genotype);

            return UnitOfWork.Complete() >0 ? ReasonCode.Created : ReasonCode.OperationFailed;
        }

        public ReasonCode Update(GenotypeViewModel viewModel)
        {
            var genotype = UnitOfWork.GenotypeRepository.Find(viewModel.Id);
            if (genotype ==null)
            {
                return ReasonCode.NotFound;
            }

            genotype.Name = viewModel.Name;

            UnitOfWork.GenotypeRepository.Update(genotype);

            return UnitOfWork.Complete() >0? ReasonCode.Updated: ReasonCode.OperationFailed;
        }
    }
}
