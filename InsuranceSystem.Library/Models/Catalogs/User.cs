namespace InsuranceSystem.Library.Models.Catalogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class User : Catalog
    {
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

        // Main parameters for documents
        public int FirmId { get; set; }
        public virtual Firm Firm { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public int SalesOfficeId { get; set; }
        public virtual SalesOffice SalesOffice { get; set; }

    }
}
