namespace InsuranceSystem.MVC.Models.Catalogs
{
    public class BankModel : CatalogModel
    {
        public string MFO { get; set; }
        public string FullName { get; set; }
        public string EDRPOU { get; set; }
        public string CorrespondingAccount { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Phones { get; set; }
        public string Rate { get; set; }
        public string RateSource { get; set; }

    }
}
