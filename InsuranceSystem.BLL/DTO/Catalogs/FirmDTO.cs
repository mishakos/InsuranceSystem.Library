namespace InsuranceSystem.BLL.DTO.Catalogs
{
    using Enums;

    public class FirmDTO : CatalogDTO
    {
        public string FullName { get; set; }
        public string EDRPOU { get; set; }
        public LegalTypeDTO LegalType { get; set; }
        public int? LegalAdressId { get; set; }
        public int? FactAdressId { get; set; }
        public int? BankAccountId { get; set; }
    }
}
