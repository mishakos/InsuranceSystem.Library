
namespace InsuranceSystem.Library.Models.Registries
{
    using Catalogs;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class RegBlankMotion : PeriodicalInfoRegistry
    {
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
        public int SalesOfficeID { get; set; }
        public virtual SalesOffice SalesOffice { get; set; }
        [Key, Column(Order = 5)]
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
        public int QuantityRevenues { get; set; }
        public int QuantityExtends { get; set; }
    }
}
