namespace InsuranceSystem.Library.Models.Catalogs
{
    using System.Collections.Generic;

    public class Model : Catalog
    {
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual List<Vehicle> Vehicles { get; set; }

    }
}