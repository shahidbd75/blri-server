using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLRI.Entity;
using BLRI.ViewModel.LookUp;

namespace BLRI.Manager.Map
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AnimalCategory, AnimalCategoryViewModel>().ReverseMap();
            //CreateMap<>()
        }
    }
}
