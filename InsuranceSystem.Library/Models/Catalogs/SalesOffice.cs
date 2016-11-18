namespace InsuranceSystem.Library.Models.Catalogs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SalesOffice : Catalog
    {
        [Required]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
