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
            CreateMap<AreaOfUseDTO, AreaOfUseModel>();
            CreateMap<BankAccountDTO, BankAccountModel>();
            CreateMap<BankDTO, BankModel>();
            CreateMap<BlankDTO, BlankModel>();
            CreateMap<BlankTypeDTO, BlankTypeModel>();
            CreateMap<BrandDTO, BrandModel>();
            CreateMap<BonusMalusDTO, BonusMalusModel>();
            CreateMap<ClientDTO, ClientModel>();
            CreateMap<ContractTermDTO, ContractTermModel>();
            CreateMap<CurrencyDTO, CurrencyModel>();
        }

        private static void CreateMap<T, U>() where T : CatalogDTO where U : CatalogModel
        {
            Mapper.CreateMap<T, U>().ReverseMap()
                .ForSourceMember(src => src.DateCreate, opt => opt.Ignore())
                .ForSourceMember(src => src.Id, opt => opt.Ignore())
                .ForSourceMember(src => src.ModifiedDate, opt => opt.Ignore());
        }
    }
}