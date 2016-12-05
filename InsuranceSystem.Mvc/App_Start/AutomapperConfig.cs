using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using InsuranceSystem.BLL.DTO.Catalogs;
using InsuranceSystem.MVC.Models.Catalogs;

namespace InsuranceSystem.Mvc.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.CreateMap<BankDTO, BankModel>().ReverseMap()
                .ForSourceMember(src => src.DateCreate, opt => opt.Ignore())
                .ForSourceMember(src => src.Id, opt => opt.Ignore())
                .ForSourceMember(src => src.ModifiedDate, opt => opt.Ignore());
            Mapper.CreateMap<BlankDTO, BlankModel>().ReverseMap()
                .ForSourceMember(src => src.DateCreate, opt => opt.Ignore())
                .ForSourceMember(src => src.Id, opt => opt.Ignore())
                .ForSourceMember(src => src.ModifiedDate, opt => opt.Ignore());
            Mapper.CreateMap<BlankTypeDTO, BlankTypeModel>().ReverseMap()
                .ForSourceMember(src => src.DateCreate, opt => opt.Ignore())
                .ForSourceMember(src => src.Id, opt => opt.Ignore())
                .ForSourceMember(src => src.ModifiedDate, opt => opt.Ignore());
            Mapper.CreateMap<BrandDTO, BrandModel>().ReverseMap()
                .ForSourceMember(src => src.DateCreate, opt => opt.Ignore())
                .ForSourceMember(src => src.Id, opt => opt.Ignore())
                .ForSourceMember(src => src.ModifiedDate, opt => opt.Ignore());
        }
    }
}