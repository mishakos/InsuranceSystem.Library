using System.Collections.Generic;
using InsuranceSystem.Library.Models.Catalogs;
using InsuranceSystem.Library.Models.Registries;

namespace InsuranceSystem.Library.Models.Documents
{
    public class PostBlank : Document
    {
        public int MRPersonId { get; set; }
        public Person MRPerson { get; set; }
        public List<PostBlankItem> BlankItems { get; set; }
        public virtual List<RegistryBlankStatus> RegistryBlankStatuses { get; set; }

    }
}
