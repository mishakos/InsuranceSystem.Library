using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceSystem.Library.Models.Catalogs
{
    public class BankAccount : Catalog
    {
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        [MaxLength(20)]
        [Required]
        public string AccountNumber { get; set; }
        [Required]
        public int BankId { get; set; }
        public virtual Bank Bank { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        [MaxLength(160)]
        public string PurposeOfPayment { get; set; }

    }
}
