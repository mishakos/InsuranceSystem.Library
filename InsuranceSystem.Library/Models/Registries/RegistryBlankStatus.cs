using InsuranceSystem.Library.Models.Catalogs;
using InsuranceSystem.Library.Models.Documents;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceSystem.Library.Models.Registries
{
    public class RegistryBlankStatus : PeriodicalInfoRegistry
    {
        [Key, Column(Order = 1)]
        public int BlankId { get; set; }
        public virtual Blank Blank { get; set; }
        [Key, Column(Order = 2)]
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
        [Key, Column(Order = 3)]
        public int PostBlankId { get; set; }
        public virtual PostBlank PostBlank { get; set; }        
        public int MTPLPolicyId { get; set; }
        public virtual MTPLPolicy MTPLPolicy { get; set; }
        public int Quantity { get; set; }

    }
}
