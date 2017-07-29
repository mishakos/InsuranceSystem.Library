using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InsuranceSystem.BLL.DTO.Catalogs;
using InsuranceSystem.Library.Models.Catalogs;
using InsuranceSystem.Library.Models.Enums;
using InsuranceSystem.BLL.DTO.Enums;

namespace InsuranceSystem.BLL.Infrastructure
{
    public class AutoMapperConfig
    {
        private static AutoMapperConfig autoMapperConfig;

        private AutoMapperConfig()
        {
            Config();
        }

        public void Config()
        {

            // Catalogs
            Mapper.Initialize(c =>
            {
                CreateMap<AreaOfUse, AreaOfUseDTO>(c);
                CreateMap<Address, AddressDTO>(c);
                CreateMap<Bank, BankDTO>(c);
                CreateMap<BankAccount, BankAccountDTO>(c);
                CreateMap<Client, ClientDTO>(c);
                CreateMap<Blank, BlankDTO>(c);
                CreateMap<BonusMalus, BonusMalusDTO>(c);
                CreateMap<BlankType, BlankTypeDTO>(c);
                CreateMap<Brand, BrandDTO>(c);
                CreateMap<ContractTerm, ContractTermDTO>(c);
                CreateMap<Currency, CurrencyDTO>(c);
                CreateMap<Department, DepartmentDTO>(c);
                CreateMap<DocumentCategory, DocumentCategoryDTO>(c);
                CreateMap<DriverExperience, DriverExperienceDTO>(c);
                CreateMap<DriversNumber, DriversNumberDTO>(c);
                CreateMap<Firm, FirmDTO>(c);
                CreateMap<FraudAttempt, FraudAttemptDTO>(c);
                CreateMap<InsuranceProduct, InsuranceProductDTO>(c);
                CreateMap<InsuranceType, InsuranceTypeDTO>(c);
                CreateMap<LocalityVehicleRegistration, LocalityVehicleRegistrationDTO>(c);
                CreateMap<Model, ModelDTO>(c);
                CreateMap<Person, PersonDTO>(c);
                CreateMap<SalesOffice, SalesOfficeDTO>(c);
                CreateMap<Status, StatusDTO>(c);
                CreateMap<TerritoryRegistration, TerritoryRegistrationDTO>(c);
                CreateMap<Vehicle, VehicleDTO>(c);
                CreateMap<VehiclesNumber, VehiclesNumberDTO>(c);
            });
        }


        private static IMappingExpression<U, T> CreateMap<T, U>(IMapperConfigurationExpression c)
            where T : Catalog
            where U : CatalogDTO
        {
            return c.CreateMap<T, U>()
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
