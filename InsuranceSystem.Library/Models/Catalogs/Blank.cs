using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceSystem.Library.Models.Registries;

namespace InsuranceSystem.Library.Models.Catalogs
{
    public class Blank : Catalog
    {
        public int BlankTypeId { get; set; }
        public BlankType BlankType { get; set; }

        // Registries
        public virtual List<RegistryBlankStatus> Statuses { get; set; }

    }
}
