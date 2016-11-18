namespace InsuranceSystem.BLL.DTO.Catalogs
{
    public class ClientDTO : CatalogDTO
    {
        public string FullName { get; set; }
        public string EDRPOU { get; set; }
        public string ITN { get; set; }
        public int? FactAddressId { get; set; }
        public int? LegalAddressId { get; set; }
        public int? BancAccountId { get; set; }

    }
}
