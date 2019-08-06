using System;
using BLRI.Entity;
using BLRI.Entity.Animals;
using BLRI.Entity.Auth;
using BLRI.ViewModel.Animals;
using BLRI.ViewModel.Auth;
using BLRI.ViewModel.Biometric;
using BLRI.ViewModel.Breeding;
using BLRI.ViewModel.Live_Weight;

namespace BLRI.Manager.Map
{
    public static class ModelUpdater
    {
        public static void UpdateUserModel(this User user, UserViewModel viewModel)
        {
            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.Email = viewModel.Email;
            user.PhoneNumber = viewModel.PhoneNumber;
            user.UserName = viewModel.UserName;
        }

        public static void UpdateAnimal(this Animal entity, AnimalViewModel viewModel)
        {
            entity.AIdNew = viewModel.AIdNew;
            entity.AIdOld = viewModel.AIdOld;
            entity.GenotypeId = viewModel.GenotypeId;
            entity.BirthDate = viewModel.BirthDate;
            entity.BirthSession = viewModel.BirthSession;
            entity.CategoryId = viewModel.CategoryId;
            entity.Year = viewModel.BirthDate.Year;
            entity.DamId = viewModel.DamId;
            entity.SireId = viewModel.SireId;
            entity.Generation = viewModel.Generation;
            entity.Gender = viewModel.Gender;
            entity.DamParity = viewModel.DamParity;
        }

        public static void UpdateBiometric(this Biometric entity, BiometricViewModel viewModel)
        {
            entity.AnimalId = viewModel.AnimalId;
            entity.BiometricUnitId = viewModel.BiometricUnitId;
            entity.BodyLength = viewModel.BodyLength;
            entity.ChestGirth = viewModel.ChestGirth;
            entity.EarBreadth = viewModel.EarBreadth;
            entity.EarLength = viewModel.EarLength;
            entity.HeadBreadth = viewModel.HeadBreadth;
            entity.HeadLength = viewModel.HeadLength;
            entity.HipHeight = viewModel.HipHeight;
            entity.HornCircumference = viewModel.HornCircumference;
            entity.HornLength = viewModel.HornLength;
            entity.LegLengthFront = viewModel.LegLengthFront;
            entity.LegLengthHind = viewModel.LegLengthHind;
            entity.TeatBreadth = viewModel.TeatBreadth;
            entity.TeatCircumference = viewModel.TeatCircumference;
            entity.TeatLength = viewModel.TeatLength;
            entity.TestesBreadth = viewModel.TestesBreadth;
            entity.TestesCircumference = viewModel.TestesCircumference;
            entity.NeckBreadth = viewModel.NeckBreadth;
            entity.NeckLength = viewModel.NeckLength;
            entity.RumpLength = viewModel.RumpLength;
            entity.RumpWidth = viewModel.RumpWidth;
            entity.UdderBreadth = viewModel.UdderBreadth;
            entity.UdderCircumference = viewModel.UdderCircumference;
            entity.UdderLength = viewModel.UdderLength;
            entity.WitherHeight = viewModel.WitherHeight;
            entity.TestesLength = viewModel.TestesLength;
            entity.TailLength = viewModel.TailLength;
            entity.TailCircumference = viewModel.TailCircumference;
        }

        public static void UpdateBreeding(this Breeding breeding, BreedingViewModel viewModel)
        {
            breeding.FirstCalvingDate = viewModel.FirstCalvingDate;
            breeding.FirstConceptionDate = viewModel.FirstConceptionDate;
            breeding.FirstHeatDate = viewModel.FirstHeatDate;
            breeding.WeaningDate = viewModel.WeaningDate;
            breeding.AnimalId = viewModel.AnimalId;
        }

        public static void UpdateLiveWeight(this LiveWeight liveWeight, LiveWeightViewModel viewModel)
        {
            liveWeight.AnimalId = viewModel.AnimalId;
            liveWeight.WeightUnitId = viewModel.WeightUnitId;
            liveWeight.WeightValue = viewModel.WeightValue;
        }
    }
}
