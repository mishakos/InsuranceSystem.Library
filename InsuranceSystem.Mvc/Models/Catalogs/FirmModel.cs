namespace InsuranceSystem.MVC.Models.Catalogs
{
    using Enums;

    public class FirmModel : CatalogModel
    {
        public string FullName { get; set; }
        public string EDRPOU { get; set; }
        public LegalTypeModel LegalType { get; set; }
        public int? LegalAdressId { get; set; }
        public int? FactAdressId { get; set; }
        public int? BankAccountId { get; set; }
    }
}
