using InsuranceSystem.Library.Models.Catalogs;
using System.ComponentModel.DataAnnotations;

namespace InsuranceSystem.Library.Models.Documents
{
    public class MoveBlankItem
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int MoveBlankId { get; set; }
        public virtual MoveBlank MoveBlank { get; set; }
        [Required]
        public int BlankId { get; set; }
        public virtual Blank Blank { get; set; }
    }
}