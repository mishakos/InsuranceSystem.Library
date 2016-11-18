namespace InsuranceSystem.Library.Models.Catalogs
{
    using Documents;
    using System.Collections.Generic;

    public class AreaOfUse : Catalog
    {
        public virtual List<MTPLPolicy> MTPLPolicies { get; set; }
       

    }
}
