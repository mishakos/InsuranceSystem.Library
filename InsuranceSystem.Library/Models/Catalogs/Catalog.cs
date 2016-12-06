using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceSystem.Library.Models.Catalogs
{
    public abstract class Catalog
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(256)]
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsDelete { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        [Required]
        public DateTime ModifiedDate { get; set; }
        public bool IsGroup { get; set; }
        public int? ParentId { get; set; }
        

    }
}
