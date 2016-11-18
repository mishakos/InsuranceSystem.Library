using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceSystem.Library.Models.Catalogs
{
    public class Person : Catalog
    {
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string MiddleName { get; set; }
        [MaxLength(150)]
        public string DocumentType { get; set; }
        [MaxLength(10)]
        public string DocumentSeries { get; set; }
        [MaxLength(25)]
        public string DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }
        [MaxLength(1024)]
        public string DocumentIssuer { get; set; }
        public DateTime Birthdate { get; set; }
        [MaxLength(12)]
        public string CodeDRFO { get; set; }
        [MaxLength(50)]
        public string EMail { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

    }
}
