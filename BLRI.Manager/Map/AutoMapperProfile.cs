using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLRI.Entity;
using BLRI.Entity.Animals;
using BLRI.Entity.Units;
using BLRI.ViewModel.Animals;
using BLRI.ViewModel.Biometric;
using BLRI.ViewModel.Breeding;
using BLRI.ViewModel.Growth;
using BLRI.ViewModel.Health;
using BLRI.ViewModel.Live_Weight;
using BLRI.ViewModel.LookUp;
using BLRI.ViewModel.Milk_Yield;
using BLRI.ViewModel.Semen;
using BLRI.ViewModel.Units;

namespace BLRI.Manager.Map
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AnimalCategory, AnimalCategoryViewModel>().ReverseMap();
            CreateMap<Animal, AnimalViewModel>().ReverseMap();
            CreateMap<Biometric, BiometricViewModel>().ReverseMap();
            CreateMap<Genotype, GenotypeViewModel>().ReverseMap();
            CreateMap<BiometricUnit, BiometricUnitViewModel>().ReverseMap();
            CreateMap<GrowthUnit, GrowthUnitViewModel>().ReverseMap();
            CreateMap<WeightUnit, WeightUnitViewModel>().ReverseMap();
            CreateMap<Health, HealthViewModel>().ReverseMap();
            CreateMap<Semen, SemenViewModel>().ReverseMap();
            CreateMap<Breeding, BreedingViewModel>().ReverseMap();
            CreateMap<Growth, GrowthViewModel>().ReverseMap();
            CreateMap<LiveWeight, LiveWeightViewModel>().ReverseMap();
            CreateMap<MilkYield, MilkYieldViewModel>().ReverseMap();

            //CreateMap<>()
        }
    }
}
