namespace InsuranceSystem.MVC.Models.Catalogs
{
    public class AdressDTO : CatalogModel
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
