using AutoMapper;
using InsuranceSystem.BLL.DTO.Catalogs;
using InsuranceSystem.MVC.Models.Catalogs;

namespace InsuranceSystem.Mvc.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            // Catalogs
            CreateMap<AreaOfUseDTO, AreaOfUseModel>();
            //CreateMap<AddressDTO, AddressModel>();
            //CreateMap<BankDTO, BankModel>();
            //CreateMap<BankAccountDTO, BankAccountModel>();
            //CreateMap<ClientDTO, ClientModel>();
            //CreateMap<BlankDTO, BlankModel>();
            //CreateMap<BonusMalusDTO, BonusMalusModel>();
            //CreateMap<BlankTypeDTO, BlankTypeModel>();
            //CreateMap<BrandDTO, BrandModel>();
            //CreateMap<ContractTermDTO, ContractTermModel>();
            //CreateMap<CurrencyDTO, CurrencyModel>();
            //CreateMap<DepartmentDTO, DepartmentModel>();
            //CreateMap<DocumentCategoryDTO, DocumentCategoryModel>();
            //CreateMap<DriverExperienceDTO, DriverExperienceModel>();
            //CreateMap<DriversNumberDTO, DriversNumberModel>();
            //CreateMap<FirmDTO, FirmModel>();
            //CreateMap<FraudAttemptDTO, FraudAttemptModel>();
            //CreateMap<InsuranceProductDTO, InsuranceProductModel>();
            //CreateMap<InsuranceTypeDTO, InsuranceTypeModel>();
            //CreateMap<LocalityVehicleRegistrationDTO, LocalityVehicleRegistrationModel>();
            //CreateMap<ModelDTO, ModelModel>();
            //CreateMap<PersonDTO, PersonModel>();
            //CreateMap<SalesOfficeDTO, SalesOfficeModel>();
            //CreateMap<StatusDTO, StatusModel>();
            //CreateMap<TerritoryRegistrationDTO, TerritoryRegistrationModel>();
            //CreateMap<VehicleDTO, VehicleModel>();
            //CreateMap<VehiclesNumberDTO, VehiclesNumberModel>();
        }

        public static void CreateMap<T, U>() where T : CatalogDTO where U : CatalogModel
        {
            Mapper.Initialize( cfg => cfg.CreateMap<T, U>().ReverseMap()
                .ForSourceMember(src => src.DateCreate, opt => opt.Ignore())
                .ForSourceMember(src => src.Id, opt => opt.Ignore())
                .ForSourceMember(src => src.ModifiedDate, opt => opt.Ignore()));
        }
    }
}