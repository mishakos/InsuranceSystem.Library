namespace InsuranceSystem.Library.Models.Catalogs
{
    using Documents;
    using System.Collections.Generic;

    public class LocalityVehicleRegistration : Catalog
    {
        public virtual List<MTPLPolicy> MTPLPolices { get; set; }
    }
}
