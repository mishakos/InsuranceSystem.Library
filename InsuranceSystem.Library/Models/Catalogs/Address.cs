using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceSystem.Library.Models.Catalogs
{
    public class Address : Catalog
    {
        [MaxLength(250)]
        public string FirstLineAddress { get; set; }
        [MaxLength(250)]
        public string SecondLineAddress { get; set; }
        [MaxLength(250)]
        public string County { get; set; }
        [MaxLength(250)]
        public string City { get; set; }
        [MaxLength(250)]
        public string State { get; set; }
        [MaxLength(10)]
        public string Zip { get; set; }
        [MaxLength(250)]
        public string Country { get; set; }
    }
}
