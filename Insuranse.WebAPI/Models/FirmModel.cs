using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insuranse.WebAPI.Models
{
    public class FirmModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsGroup { get; set; }
        public int? ParentId { get; set; }
        public string ParentName { get; set; }
        public string FullName { get; set; }
        public string EDRPOU { get; set; }
        public LegalType LegalType { get; set; }
        public int? LegalAdressId { get; set; }
        public int? FactAdressId { get; set; }
        public int? BankAccountId { get; set; }

    }
}