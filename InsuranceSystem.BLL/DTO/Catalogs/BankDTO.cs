namespace InsuranceSystem.BLL.DTO.Catalogs
{
    public class BankDTO : CatalogDTO
    {
        public string MFO { get; set; }
        public string FullName { get; set; }
        public string EDRPOU { get; set; }
        public string CorrespondingAccount { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phones { get; set; }
        public string Rate { get; set; }
        public string RateSource { get; set; }

    }
}
