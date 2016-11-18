using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceSystem.Library.Models.Catalogs;

namespace InsuranceSystem.Library.Models.Documents
{
    public abstract class Document
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Number { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public bool IsHold { get; set; }
        [Required]
        public bool IsDelete { get; set; }
        [Required]
        public DateTime AddDate { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
