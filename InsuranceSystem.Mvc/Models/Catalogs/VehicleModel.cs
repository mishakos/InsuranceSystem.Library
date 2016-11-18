namespace InsuranceSystem.MVC.Models.Catalogs
{
    using System;

    public class VehicleModel : CatalogModel
    {
        public int ModelId { get; set; }
        public int BrandId { get; set; }

        public string Vin { get; set; }
        public string RegNumber { get; set; }
        public string Comments { get; set; }
        public int EngineCapacity { get; set; }
        public DateTime OperationFrom { get; set; }
        public decimal Load { get; set; }
        public string PlaceOfRegistration { get; set; }
        public DateTime SertificateDate { get; set; }
        public string SertificateSeries { get; set; }
        public string SertificateNumber { get; set; }
        public string SertificateIssuer { get; set; }


    }
}
