using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceSystem.Library.Models.Catalogs
{
    public class Bank : Catalog
    {
        public virtual Bank Parent { get; set; }
        [MaxLength(6)]
        public string MFO { get; set; }
        [MaxLength(1024)]
        public string FullName { get; set; }
        [MaxLength(10)]
        public string EDRPOU { get; set; }
        [MaxLength(25)]
        public string CorrespondingAccount { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(250)]
        public string Adress { get; set; }
        [MaxLength(200)]
        public string Phones { get; set; }
        [MaxLength(10)]
        public string Rate { get; set; }
        [MaxLength(200)]
        public string RateSource { get; set; }

    }
}
