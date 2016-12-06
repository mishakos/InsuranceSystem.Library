using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceSystem.Library.Models.Registries;

namespace InsuranceSystem.Library.Models.Catalogs
{
    public class Blank : Catalog
    {
        public int? BlankTypeId { get; set; }
        [ForeignKey("BlankTypeId")]
        public virtual BlankType BlankType { get; set; }
        [ForeignKey("ParentId")]
        public virtual Blank Parent { get; set; }
        
        // Registries
        public virtual List<RegistryBlankStatus> Statuses { get; set; }

    }
}
