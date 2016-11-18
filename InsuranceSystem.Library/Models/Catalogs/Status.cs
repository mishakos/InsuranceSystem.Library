using System.Collections.Generic;
using InsuranceSystem.Library.Models.Registries;

namespace InsuranceSystem.Library.Models.Catalogs
{
    public class Status : Catalog
    {
        public virtual List<RegistryBlankStatus> RegistryBlankStatus { get; set; }

    }
}
