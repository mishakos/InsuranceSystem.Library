namespace InsuranceSystem.Library.Models.Catalogs
{
    using Documents;
    using System.Collections.Generic;

    public class InsuranceProduct : Catalog
    {
        public string ShortKey { get; set; }
        
        public virtual List<MTPLPolicy> MTPLPolicies { get; set; }

    }
}
