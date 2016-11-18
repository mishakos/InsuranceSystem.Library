namespace InsuranceSystem.Library.Models.Registries
{
    using Catalogs;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RegBlankRest
    {
        [Key, Column(Order = 0)]
        public DateTime Period { get; set; }
        public bool IsActive { get; set; }
        // Dimensions
        [Key, Column(Order = 1)]
        public int BlankId { get; set; }
        public virtual Blank Blank { get; set; }
        [Key, Column(Order = 2)]
        public int FirmId { get; set; }
        public virtual Firm Firm { get; set; }
        [Key, Column(Order = 3)]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        [Key, Column(Order = 4)]
        public int SalesOfficeId { get; set; }
        public virtual SalesOffice SalesOffice { get; set; }
        [Key, Column(Order = 5)]
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
        // Resources
        public int Quantity { get; set; }

    }
}
