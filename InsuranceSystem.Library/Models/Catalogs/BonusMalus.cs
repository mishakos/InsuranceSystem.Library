namespace InsuranceSystem.Library.Models.Catalogs
{
    using Documents;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BonusMalus : Catalog
    {
        public virtual List<MTPLPolicy> MTPLPolices { get; set; }

    }
}
