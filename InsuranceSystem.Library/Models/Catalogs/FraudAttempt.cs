namespace InsuranceSystem.Library.Models.Catalogs
{
    using Documents;
    using System.Collections.Generic;

    public class FraudAttempt : Catalog
    {
        public virtual List<MTPLPolicy> MTPLPolices { get; set; }
    }
}
