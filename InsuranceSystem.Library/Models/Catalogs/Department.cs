namespace InsuranceSystem.Library.Models.Catalogs
{
    using Documents;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Department : Catalog
    {
        public int FirmId { get; set; }
        public virtual Firm Firm { get; set; }


        public virtual List<MTPLPolicy> MTPLPolicies { get; set; }
        public virtual List<SalesOffice> SalesOffices { get; set; }

    }
}
