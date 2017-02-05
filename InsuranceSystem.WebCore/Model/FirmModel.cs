using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceSystem.WebCore.Model
{
    public class FirmModel
    {
        [Display(Name = "Код")]
        public int Id { get; set; }
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Display(Name = "Помітка на вилучення")]
        public bool IsDelete { get; set; }
        [Display(Name = "Дата створення")]
        public DateTime DateCreate { get; set; }
        [Display(Name = "Дата останньої зміни")]
        public DateTime ModifiedDate { get; set; }
        [Display(Name = "Це група")]
        public bool IsGroup { get; set; }
        [Display(Name = "Група")]
        public int? ParentId { get; set; }
        [Display(Name = "Група")]
        public string ParentName { get; set; }
        public string FullName { get; set; }
        public string EDRPOU { get; set; }
        public LegalTypeModel LegalType { get; set; }
        public int? LegalAdressId { get; set; }
        public int? FactAdressId { get; set; }
        public int? BankAccountId { get; set; }

    }
}
