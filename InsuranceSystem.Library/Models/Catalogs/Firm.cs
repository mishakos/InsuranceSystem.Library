using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceSystem.Library.Models.Enums;

namespace InsuranceSystem.Library.Models.Catalogs
{
    public class Firm : Catalog
    {
        [MaxLength(1024)]
        public string FullName { get; set; }
        [MaxLength(15)]
        public string EDRPOU { get; set; }
        public LegalType LegalType { get; set; }
        public int? LegalAdressId { get; set; }
        public virtual Address LegalAdress { get; set; }
        public int? FactAdressId { get; set; }
        public virtual Address FactAdress { get; set; }
        public int? BankAccountId { get; set; }
        public virtual BankAccount BankAccount { get; set; }
    }
}
