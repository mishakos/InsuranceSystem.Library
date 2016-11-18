namespace InsuranceSystem.BLL.DTO.Catalogs
{
    public class AdressDTO : CatalogDTO
    {
        public string FirstLineAdress { get; set; }
        public string SecondLineAdress { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
    }
}
