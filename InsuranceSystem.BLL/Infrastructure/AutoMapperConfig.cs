using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InsuranceSystem.BLL.DTO.Catalogs;
using InsuranceSystem.Library.Models.Catalogs;

namespace InsuranceSystem.BLL.Infrastructure
{
    public class AutoMapperConfig
    {
        private static AutoMapperConfig autoMapperConfig;

        private AutoMapperConfig()
        {
            Config();
        }

        private void Config()
        {
            // Catalogs
            Mapper.CreateMap<Bank, BankDTO>()
                .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.Parent.Name))
                .ReverseMap().ForSourceMember(src => src.Id, opt => opt.Ignore())
                             .ForSourceMember(src => src.DateCreate, opt => opt.Ignore())
                             .ForSourceMember(src => src.ModifiedDate, opt => opt.Ignore()); ;
            Mapper.CreateMap<Blank, BlankDTO>()
                .ForMember(dest => dest.BlankTypeName, opt => opt.MapFrom(src => src.BlankType.Name))
                .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.Parent.Name))
                .ReverseMap().ForSourceMember(src => src.Id, opt => opt.Ignore())
                            .ForSourceMember(src => src.DateCreate, opt => opt.Ignore())
                            .ForSourceMember(src => src.ModifiedDate, opt => opt.Ignore());
            Mapper.CreateMap<BonusMalus, BonusMalusDTO>()
                .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.Parent.Name))
                .ReverseMap().ForSourceMember(src => src.Id, opt => opt.Ignore())
                             .ForSourceMember(src => src.DateCreate, opt => opt.Ignore())
                             .ForSourceMember(src => src.ModifiedDate, opt => opt.Ignore());
        }

        public static AutoMapperConfig Instance
        {
            get
            {
                if (autoMapperConfig == null)
                {
                    autoMapperConfig = new AutoMapperConfig();
                }
                return autoMapperConfig;
            }
        }

    }
}
