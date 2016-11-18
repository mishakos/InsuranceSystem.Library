namespace InsuranceSystem.Library.Models.Catalogs
{
    using System.Collections.Generic;

    public class Brand : Catalog
    {
        public virtual List<Model> Models { get; set; }
        public virtual List<Vehicle> Vehicles { get; set; }

    }
}
