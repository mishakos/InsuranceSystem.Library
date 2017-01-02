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
            CreateMap<AreaOfUse, AreaOfUseDTO>();
            CreateMap<Address, AddressDTO>();
            CreateMap<Bank, BankDTO>();
            CreateMap<BankAccount, BankAccountDTO>();
            CreateMap<Client, ClientDTO>();
            CreateMap<Blank, BlankDTO>();
            CreateMap<BonusMalus, BonusMalusDTO>();
            CreateMap<BlankType, BlankTypeDTO>();
            CreateMap<Brand, BrandDTO>();
            CreateMap<ContractTerm, ContractTermDTO>();
            CreateMap<Currency, CurrencyDTO>();
            CreateMap<Department, DepartmentDTO>();
            CreateMap<DocumentCategory, DocumentCategoryDTO>();
            CreateMap<DriverExperience, DriverExperienceDTO>();
            CreateMap<DriversNumber, DriversNumberDTO>();
            CreateMap<Firm, FirmDTO>();
            CreateMap<FraudAttempt, FraudAttemptDTO>();
            CreateMap<InsuranceProduct, InsuranceProductDTO>();
            CreateMap<InsuranceType, InsuranceTypeDTO>();
            CreateMap<LocalityVehicleRegistration, LocalityVehicleRegistrationDTO>();
            CreateMap<Model, ModelDTO>();
            CreateMap<Person, PersonDTO>();
            CreateMap<SalesOffice, SalesOfficeDTO>();
            CreateMap<Status, StatusDTO>();
            CreateMap<TerritoryRegistration, TerritoryRegistrationDTO>();
            CreateMap<Vehicle, VehicleDTO>();
            CreateMap<VehiclesNumber, VehiclesNumberDTO>();
        }

        private static void CreateMap<T, U>() where T : Catalog where U : CatalogDTO
        {
            Mapper.CreateMap<T, U>()
                //.ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.Parent.Name))
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
