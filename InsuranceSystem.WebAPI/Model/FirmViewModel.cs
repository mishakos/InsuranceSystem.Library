using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceSystem.WebAPI.Model
{
    public class FirmViewModel
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

    }
}
