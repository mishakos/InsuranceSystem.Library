using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceSystem.Library.Models.Catalogs
{
    public class Client : Catalog
    {
        [MaxLength(1024)]
        public string FullName { get; set; }
        [MaxLength(10)]
        public string EDRPOU { get; set; }
        [MaxLength(12)]
        public string ITN { get; set; }
        public int? FactAdressId { get; set; }
        public virtual Address FactAdress { get; set; }
        public int? LegalAdressId { get; set; }
        public virtual Address LegalAdress { get; set; }
        public int? BancAccountId { get; set; }
        public virtual BankAccount Account { get; set; }

    }
}
