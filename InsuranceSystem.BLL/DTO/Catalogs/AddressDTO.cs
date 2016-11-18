namespace InsuranceSystem.BLL.DTO.Catalogs
{
    public class AddressDTO : CatalogDTO
    {
        public string FirstLineAdress { get; set; }
        public string SecondLineAdress { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"{FirstLineAdress} {SecondLineAdress} {County} {City} {State} {Zip} {Country} ({Id})";
        }
    }
}
