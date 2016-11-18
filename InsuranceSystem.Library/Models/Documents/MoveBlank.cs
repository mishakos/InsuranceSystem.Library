
namespace InsuranceSystem.Library.Models.Documents
{
    using Catalogs;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class MoveBlank : Document
    {
        [Required]
        public int FromPersonId { get; set; }
        public virtual Person FromPerson { get; set; }
        [Required]
        public int ToPersonId { get; set; }
        public virtual Person ToPerson { get; set; }
        public virtual List<MoveBlankItem> MoveBlankItems { get; set; }


    }
}
