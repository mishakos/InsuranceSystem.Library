using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceSystem.Library.Models.Catalogs
{
    public class Currency : Catalog
    {
        [MaxLength(3)]
        [Required]
        public string Code { get; set; }
        [MaxLength(20)]
        [Required]
        public new string Name { get; set; }
        [MaxLength(50)]
        public string FullName { get; set; }
        [MaxLength(250)]
        public string ParametresForInWords { get; set; }

        public virtual List<BankAccount> Accounts { get; set; }


    }
}
