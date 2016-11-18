namespace InsuranceSystem.MVC.Models.Catalogs
{
    public class ClientModel : CatalogModel
    {
        public string FullName { get; set; }
        public string EDRPOU { get; set; }
        public string ITN { get; set; }
        public int? FactAdressId { get; set; }
        public int? LegalAdressId { get; set; }
        public int? BancAccountId { get; set; }

    }
}
